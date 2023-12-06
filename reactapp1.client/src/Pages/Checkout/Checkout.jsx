import React from 'react'
import { useState } from 'react'
import { useEffect } from 'react'
import { useParams } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import "./Checkout.css"

export const Checkout = () => {
    const navigate = useNavigate();
    const { reference, quantity } = useParams();

    const [validationErrors, setValidationErrors] = useState([]);

    const [customer, setCustomer] = useState({
        name: "",
        email: "",
        address: {
            street: "",
            city: "",
            county: "",
            postcode: ""
        },
        card: {
            cardName: "",
            cardNumber: "",
            expMonth: "",
            expYear: "",
            cvv: ""
        }
    });

    const updateCard = (cardChanges) => {
        setCustomer({ ...customer, ...{ card: { ...customer.card, ...cardChanges } } });
    }

    const updateAddress = (addressChanges) => {
        setCustomer({ ...customer, ...{ address: { ...customer.address, ...addressChanges } } });
    }

    const updateCustomer = (customerChanges) => {
        setCustomer({ ...customer, ...customerChanges });
    }

    const validatePage = () => {
        let errors = [];

        if (!customer.name) {
            errors.push("Name is required");
        }

        if (!customer.email) {
            errors.push("Email is required");
        }

        if (!customer.card.cardNumber) {
            errors.push("Card number is required");
        }

        setValidationErrors(errors);

        return errors.length == 0;
    }

    const confirmPurchase = () => {
        if (validatePage()) {
            var model = { Customer: customer, ProductReference: reference, ProductQuantity: quantity }

            fetch('https://localhost:7044/Order/ConfirmOrder/', {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(model)
            })
                .then(response => response.json())
                .then(result => {
                    if (result.orderReference) {
                        navigate("/OrderSummary/" + result.orderReference);
                    }
                });
        }
    }


    return (
        <main className="container">
            <div className="row">
                <ul>
                    {
                        validationErrors.map((error, ix) => {
                            return (<><li key={ix}>{error}</li></>)
                        })
                    }
                </ul>
                <div className="col-75">
                    <div className="container">
                        <form>
                            <div className="row">
                                <div className="col-50">
                                    <h3>Billing Address</h3>
                                    <label htmlFor="fname"><i className="fa fa-user"></i> Full Name</label>
                                    <input type="text" id="fname" name="firstname" placeholder="John M. Doe" value={customer.name} onChange={(e) => updateCustomer({ name: e.target.value})} />
                                    <label htmlFor="email"><i className="fa fa-envelope"></i> Email</label>
                                    <input type="text" id="email" name="email" placeholder="john@example.com" value={customer.email} onChange={(e) => updateCustomer({ email: e.target.value })} />
                                    <label htmlFor="adr"><i className="fa fa-address-card-o"></i> Number/Street Name</label>
                                    <input type="text" id="adr" name="address" placeholder="542 W. 15th Street" value={customer.address.street} onChange={(e) => updateAddress({ street: e.target.value })} />
                                    <label htmlFor="city"><i className="fa fa-institution"></i> City</label>
                                    <input type="text" id="city" name="city" placeholder="New York" value={customer.address.city} onChange={(e) => updateAddress({ city: e.target.value })} />

                                    <div className="row">
                                        <div className="col-50">
                                            <label htmlFor="state">County</label>
                                            <input type="text" id="county" name="county" placeholder="Derbyshire" value={customer.address.county} onChange={(e) => updateAddress({ county: e.target.value })} />
                                        </div>
                                        <div className="col-50">
                                            <label htmlFor="post">Postcode</label>
                                            <input type="text" id="post" name="post" placeholder="AA22 AAA" value={customer.address.postcode} onChange={(e) => updateAddress({ postcode: e.target.value })} />
                                        </div>
                                    </div>
                                </div>

                                <div className="col-50">
                                    <h3>Payment</h3>
                                    <label htmlFor="cname">Name on Card</label>
                                    <input type="text" id="cname" name="cardname" placeholder="John More Doe" value={customer.card.cardName} onChange={(e) => updateCard({ cardName: e.target.value })} />
                                    <label htmlFor="ccnum">Credit card number</label>
                                    <input type="text" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444" value={customer.card.cardNumber} onChange={(e) => updateCard({ cardNumber: e.target.value })} />
                                    <label htmlFor="expmonth">Exp Month</label>
                                    <input type="text" id="expmonth" name="expmonth" placeholder="September" value={customer.card.expMonth} onChange={(e) => updateCard({ expMonth: e.target.value })} />
                                    
                                    <div className="row">
                                        <div className="col-50">
                                            <label htmlFor="expyear">Exp Year</label>
                                            <input type="text" id="expyear" name="expyear" placeholder="2018" value={customer.card.expYear} onChange={(e) => updateCard({ expYear: e.target.value })} />
                                        </div>
                                        <div className="col-50">
                                            <label htmlFor="cvv">CVV</label>
                                            <input type="text" id="cvv" name="cvv" placeholder="352" value={customer.card.cvv} onChange={(e) => updateCard({ cvv: e.target.value })} />
                                        </div>
                                    </div>
                                </div>

                                <input value="Confirm Order" className="btn" onClick={confirmPurchase} />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </main>
    )
}
