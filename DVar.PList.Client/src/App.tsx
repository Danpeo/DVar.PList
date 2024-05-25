import "./App.css";
import { Home } from "./pages/Home.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { PricelistInfo } from "./pages/PricelistInfo.tsx";
import {AddProductToPricelist} from "./pages/AddProductToPricelist.tsx";

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/pricelist/:pricelistId" element={<PricelistInfo />} />
          <Route path="/pricelist/:pricelistId/add-product/:pricelistId" element={<AddProductToPricelist />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
