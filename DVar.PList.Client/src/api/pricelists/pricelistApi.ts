import axios from "axios";
import { serverUrl } from "../../constants/server.ts";
import { Product } from "../../entities/product.ts";

const endpoint = "PriceLists";

export const listPricelists = async (
  paginationParams: PaginationParams,
): Promise<ListPricelistsResponse[]> => {
  const { data } = await axios.get<ListPricelistsResponse[]>(
    `${serverUrl}/${endpoint}?PageNumber=${paginationParams.pageNumber}&PageSize=${paginationParams.pageSize}`,
  );
  return data;
};

export const getPricelist = async (
  id: string,
): Promise<GetPricelistResponse> => {
  const { data } = await axios.get<GetPricelistResponse>(
    `${serverUrl}/${endpoint}/${id}`,
  );
  return data;
};

export const addProductToPricelist = async (
  pricelistId: string,
  product: Product,
) => {
  await axios.patch(
    `${serverUrl}/${endpoint}/AddProduct/${pricelistId}`,
    product,
  );
};

export const addProductToPricelistAlt = (
  pricelistId: string,
  product: Product,
) => {
  const url = `${serverUrl}/${endpoint}/AddProduct/${pricelistId}`;

  fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(product),
  }).then((response) => response.json());
};
