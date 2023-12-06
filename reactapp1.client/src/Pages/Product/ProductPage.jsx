import React from 'react'
import { useState } from 'react'
import { useParams } from 'react-router-dom';
import "./ProductPage.css"
import { useNavigate } from "react-router-dom";

export const ProductPage = () => {
    const [product, setProduct] = useState();
    const [quantity, setQuantity] = useState(1);

    const navigate = useNavigate();

    const { reference } = useParams();

    React.useEffect(() => {
        fetch('https://localhost:7044/Product/GetProduct/' + reference)
            .then(result => result.json())
            .then(response => {
                setProduct(response.product)
            })
    }, [])

    const buyClicked = () => {
        if (quantity > 0) {
            navigate("/Checkout/" + reference + "/" + quantity); //not ideal passing a quantity through like this... should be stored in a session cookie
        }
    }

    const updateQuantity = (newQty) => {
        if (quantity >= 0 && !isNaN(+newQty)) {
            setQuantity(newQty);
        }
    }

    return (
        <main className="container">
            <div className="left-column">
                <img data-image="red" className="active" src="/src/assets/DefaultProductImage.png" alt="" />
            </div>

            <div className="right-column">
                <div className="product-description">
                    <span>Baths</span>
                    <h1>{product?.name}</h1>
                    <p>{product?.description}</p>
                </div>

                <label htmlFor="cname">Quantity</label>
                <input type="text" id="quanity" name="cvv" placeholder="352" value={quantity} onChange={(e) => updateQuantity(e.target.value)} />

                <div className="product-price">
                    <span>${product?.price}</span>
                    <button onClick={buyClicked} className="cart-btn">Buy Now</button>
                </div>
            </div>
        </main>
    )
}
