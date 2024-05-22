import "./App.css";
import { Home } from "./pages/Home.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { PricelistInfo } from "./pages/PricelistInfo.tsx";

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/pricelist/:pricelistId" element={<PricelistInfo />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
