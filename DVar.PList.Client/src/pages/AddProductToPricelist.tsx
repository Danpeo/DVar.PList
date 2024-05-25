import { useParams } from "react-router-dom";
import { SubmitHandler, useForm } from "react-hook-form";
import { Fragment, useEffect, useState } from "react";
import {
  addProductToPricelist,
  getPricelist,
} from "../api/pricelists/pricelistApi.ts";
import { DataType } from "../entities/enums/dataType.ts";
import { Button } from "../components/Button.tsx";
import { Header } from "../components/Header.tsx";
import { Product } from "../entities/product.ts";
import { ProductCustomValue } from "../entities/productCustomValue.ts";
import { CustomColumn } from "../entities/customColumn.ts";

type Form = {
  productName: string;
  code: string;
  productCustomValues: ProductCustomValue[];
};

export const AddProductToPricelist = () => {
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
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<Form>();
  const onSubmit: SubmitHandler<Form> = (data) => {
    const p: ProductCustomValue[] = data.productCustomValues.map(
      (value, index) => ({
        customColumnId: pricelist?.customColumns[index].id,
        value: value.value,
      }),
    );

    const formattedData: Product = {
      productName: data.productName,
      code: data.code,
      productCustomValues: p,
    };

    if (pricelistId != null) {
      console.log(JSON.stringify(formattedData));
      addProductToPricelist(pricelistId, formattedData);
    }

    console.log(formattedData);
  };
  const inputClassName: string =
    "w-full px-3 py-2 bg-gray-800 border border-gray-900 focus:border-red-500 focus:outline-none focus:bg-gray-800 focus:text-red-500";

  const inputType = (column: CustomColumn) => {
    switch (column.dataType) {
      case DataType.Number:
        return "number";
      case DataType.MultiPageText:
        return "text";
      case DataType.SinglePageText:
        return "text";
    }
  };

  if (isLoading) {
    return (
      <>
        <p>Loading...</p>
      </>
    );
  }
  return (
    <>
      <Header>Добавление товара</Header>
      <form onSubmit={handleSubmit(onSubmit)} className="max-w-md mx-auto mt-8">
        <label className="text-2xl font-semibold mb-3">Название</label>
        <input {...register("productName")} className={inputClassName} />
        <label className="text-2xl font-semibold mb-3">Артикул</label>
        <input {...register("code")} className={inputClassName} />
        {pricelist?.customColumns.map((col, index) => (
          <Fragment key={index}>
            <label className="text-2xl font-semibold mb-3">{col.name}</label>
            <input
              key={index}
              {...register(`productCustomValues.${index}.value`)}
              type={inputType(col)}
              className={inputClassName}
            />
          </Fragment>
        ))}
        <Button type={"submit"} buttonText={"Добавить товар"} />
      </form>
    </>
  );
};
