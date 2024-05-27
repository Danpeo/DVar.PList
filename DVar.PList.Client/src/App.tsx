import "./App.css";
import { Home } from "./pages/Home.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { PricelistInfo } from "./pages/PricelistInfo.tsx";
import { AddProductToPricelist } from "./pages/AddProductToPricelist.tsx";
import { AddPricelist } from "./pages/AddPricelist.tsx";

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/add-pricelist" element={<AddPricelist />} />
          <Route path="/pricelist/:pricelistId" element={<PricelistInfo />} />
          <Route
            path="/pricelist/:pricelistId/add-product/:pricelistId"
            element={<AddProductToPricelist />}
          />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
