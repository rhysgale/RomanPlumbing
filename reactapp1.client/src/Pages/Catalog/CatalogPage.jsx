import React from 'react'
import { useState } from 'react'
import { useNavigate } from "react-router-dom";

import "./CatalogPage.css"

export const CatalogPage = () => {
    const [products, setProducts] = useState([]);
    const navigate = useNavigate();

    React.useEffect(() => {
        fetch('https://localhost:7044/Product/GetProducts', {
            method: 'POST'
        }).then(result => result.json())
            .then(response => {
                setProducts(response.products)
            })
    }, [])

    const tileClick = (reference) => {
        navigate("/product/" + reference);
    }

    return (
        <div className="grid-container">
            {
                products.map(product => {
                    return (
                        <div className="card grid-item" key={product.reference} onClick={() => tileClick(product.reference)}>
                            <img className="image" src={product.imageUrl} alt={product.name} />
                            <h1>{product.name}</h1>
                            <p className="price">${product.price}</p>
                            <p>{product.description}</p>
                        </div>
                    )
                })
            }
        </div>
    );
}
