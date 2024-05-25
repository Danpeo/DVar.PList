type GetPricelistResponse = {
  id: string;
  pricelistName: string;
  customColumns: CustomColumn[];
  products: Product[];
};