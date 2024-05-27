import axios from "axios";
import { serverUrl } from "../../constants/server.ts";
import { Product } from "../../entities/product.ts";
import { CreatePricelistRequest } from "./requests/createPricelistRequest.ts";

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

export const createPricelist = async (request: CreatePricelistRequest) => {
  await axios.post(`${serverUrl}/${endpoint}/`, request);
};

export const removeProductFromPricelist = async (
  pricelistId: string,
  productId: string,
) => {
  await axios.delete(
    `${serverUrl}/${endpoint}/Products/${pricelistId}/${productId}`,
  );
};
