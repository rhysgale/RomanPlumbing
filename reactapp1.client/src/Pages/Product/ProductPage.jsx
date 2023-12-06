import React from 'react'
import { useState } from 'react'
import { useParams } from 'react-router-dom';
import "./ProductPage.css"
import { useNavigate } from "react-router-dom";

export const ProductPage = () => {
    const [product, setProduct] = useState();
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
        navigate("/Checkout/" + reference);
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

                <div className="product-price">
                    <span>${product?.price}</span>
                    <button onClick={buyClicked} className="cart-btn">Buy Now</button>
                </div>
            </div>
        </main>
    )
}
