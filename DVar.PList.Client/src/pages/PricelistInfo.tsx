import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { getPricelist } from "../api/pricelists/pricelistApi.ts";
import { Header } from "../components/Header.tsx";

export const PricelistInfo = () => {
  const { pricelistId } = useParams();
  const [isLoading, setIsLoading] = useState(false);
  const [pricelist, setPricelist] = useState<GetPricelistResponse>();
  useEffect(() => {
    if (pricelistId != null) {
      getPricelist(pricelistId).then((data) => {
        setPricelist(data);
      });
    }
  }, [pricelistId]);

  if (isLoading) {
    return (
      <>
        <p>Loading...</p>
      </>
    );
  }
  return (
    <>
      <Header>{pricelist?.name}</Header>
      <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3">
                Название товара
              </th>
              <th scope="col" className="px-6 py-3">
                Код товара
              </th>
              {pricelist?.customColumns.map((column) => (
                <th scope="col" key={column.id} className="px-6 py-3 w-5/6">
                  {column.name}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {pricelist?.products?.map((product, index) => (
              <tr
                key={product.name}
                className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700"
              >
                <th
                  scope="row"
                  className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
                >
                  {product.name}
                </th>
                <td className="px-6 py-4">
                  {product.name}
                 
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};
