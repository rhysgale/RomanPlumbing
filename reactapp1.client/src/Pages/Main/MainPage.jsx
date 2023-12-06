export const MainPage = () => {

    const populateProductsClick = () => {
        fetch('https://localhost:7044/Data/AddTestProducts', {
            method: 'POST'
        });
    }

    return (
        <div>
            Welcome to Roman Plumbing. Please click here to populate products 
            <button onClick={populateProductsClick}>Populate test data</button>
        </div>
    );
}
