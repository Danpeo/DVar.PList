import axios from "axios";
import { serverUrl } from "../../constants/server.ts";

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
