import { CustomColumn } from "../../../entities/customColumn.ts";

export type CreatePricelistRequest = {
  name: string;
  customColumns: CustomColumn[];
};
