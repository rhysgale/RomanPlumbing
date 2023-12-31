import React from 'react'
import { useState } from 'react'
import { useParams } from 'react-router-dom';
import "./OrderSummary.css"

export const OrderSummary = () => {
    const { reference } = useParams();
    const [order, setOrder] = useState({ orderReference: reference});

    React.useEffect(() => {
        fetch('https://localhost:7044/Order/GetOrder/' + reference)
            .then(result => result.json())
            .then(response => {
                setOrder(response.orderSummary)
            });
    }, [])

    return (
        <main className="container">

            <div className="left-column">
                <img className="active" src="/src/assets/DefaultProductImage.png" alt="" />
            </div>

            <div className="right-column">
                <div className="product-description">
                    <span>Thank you for your order. </span>
                    <span>Your order reference is: {order?.orderReference}</span>
                </div>
                {
                    order?.summaryLines?.map((line, ix) => {
                        return (
                            <>
                                <div key={ix} className="product-description">
                                    <span>You have ordered {line?.productName} x{line?.quantity}</span>
                                </div>
                                <div key={ix} className="product-description">
                                    <span>Cost: ${line?.lineAmount}</span>
                                </div>
                            </>
                        )
                    })
                }
                <div>
                    Total order cost: { order?.orderTotal }
                </div>
            </div>
        </main>
    )
}
