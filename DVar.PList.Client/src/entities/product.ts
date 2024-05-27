import {ProductCustomValue} from "./productCustomValue.ts";

export type Product = {
  productName: string;
  code: string;
  productCustomValues: ProductCustomValue[];
};
