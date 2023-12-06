import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { MainPage } from "./Pages/Main/MainPage";
import { CatalogPage } from "./Pages/Catalog/CatalogPage"
import { ProductPage } from "./Pages/Product/ProductPage"
import { Checkout } from "./Pages/Checkout/Checkout"
import { OrderSummary } from "./Pages/OrderSummary/OrderSummary"
import { Layout } from "./Layout.jsx"

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route path='' element={<MainPage />} />
                    <Route path='/catalogue' element={<CatalogPage /> } />
                    <Route path='/product/:reference' element={<ProductPage />} />
                    <Route path='/checkout/:reference' element={<Checkout /> } />
                    <Route path='/ordersummary/:reference' element={<OrderSummary/>} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);