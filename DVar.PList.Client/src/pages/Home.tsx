import { Fragment, useEffect, useState } from "react";
import { listPricelists } from "../api/pricelists/pricelistApi.ts";
import { useNavigate } from "react-router-dom";
import { Header } from "../components/Header.tsx";
import {Button} from "../components/Button.tsx";
import Pagination from "../components/Pagination.tsx";

export const Home = () => {
  const navigate = useNavigate();
  const [isLoading, setIsLoading] = useState(false);
  const [pricelists, setPricelists] = useState<ListPricelistsResponse[]>();
  const [paginationParams, setPaginationParams] = useState<PaginationParams>({
    pageNumber: 0,
    pageSize: 0,
  });

  useEffect(() => {
    setIsLoading(true);

    listPricelists(paginationParams).then((data) => {
      setPricelists(data);
      setIsLoading(false);
    });
  }, []);

  if (isLoading) {
    return (
      <>
        <p>Loading...</p>
      </>
    );
  }

  return (
    <>
      <Header>Прайсы</Header>
      <Button type={"button"} buttonText={"Новый прайс"} onClick={() => navigate("add-pricelist")}/>
      <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3 w-1/6">
                №
              </th>
              <th scope="col" className="px-6 py-3 w-5/6">
                Название
              </th>
            </tr>
          </thead>
          <tbody>
            {pricelists?.map((pricelist, index) => (
              <tr
                key={pricelist.id}
                className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700"
              >
                <th
                  scope="row"
                  className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
                >
                  {index + 1}
                </th>
                <td className="px-6 py-4">
                  <button
                    className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
                    onClick={() => navigate(`pricelist/${pricelist.id}`)}
                  >
                    {pricelist.name}
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};
