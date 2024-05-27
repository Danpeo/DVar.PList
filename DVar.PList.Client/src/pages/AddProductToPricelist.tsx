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
import { BackButton } from "../components/BackButton.tsx";

type Form = {
  productName: string;
  code: string;
  productCustomValues: { value: string; dataType: DataType }[];
};

export const AddProductToPricelist = () => {
  const { pricelistId } = useParams();
  const [isLoading, setIsLoading] = useState(false);
  const [isSuccess, setIsSuccess] = useState(false);
  const [pricelist, setPricelist] = useState<GetPricelistResponse>();

  useEffect(() => {
    if (pricelistId != null) {
      setIsLoading(true);
      getPricelist(pricelistId).then((data) => {
        setPricelist(data);
        setIsLoading(false);
      });
    }
  }, [pricelistId]);

  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
    setValue,
  } = useForm<Form>();

  const onSubmit: SubmitHandler<Form> = async (data) => {
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
      try {
        await addProductToPricelist(pricelistId, formattedData);
        setIsSuccess(true);
        setTimeout(() => setIsSuccess(false), 3000);
      } catch (error) {
        console.error("Error adding product:", error);
      }
    }
  };

  const inputClassName: string =
    "w-full px-3 py-2 bg-gray-800 border border-gray-900 focus:border-red-500 focus:outline-none focus:bg-gray-800 focus:text-red-500";

  const inputType = (dataType: DataType) => {
    switch (dataType) {
      case DataType.Number:
        return "number";
      case DataType.MultiPageText:
        return "text";
      case DataType.SinglePageText:
        return "text";
      default:
        return "text";
    }
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <>
      <BackButton />
      <Header>Добавление товара</Header>
      {isSuccess && (
        <p className="text-green-500 mb-4">Товар успешно добавлен!</p>
      )}
      <form onSubmit={handleSubmit(onSubmit)} className="max-w-md mx-auto mt-8">
        <label className="text-2xl font-semibold mb-3">Название</label>
        <input
          {...register("productName", { required: "Название обязательно" })}
          className={inputClassName}
        />
        {errors.productName && (
          <p className="text-red-500">{errors.productName.message}</p>
        )}

        <label className="text-2xl font-semibold mb-3">Артикул</label>
        <input
          {...register("code", { required: "Артикул обязателен" })}
          className={inputClassName}
        />
        {errors.code && <p className="text-red-500">{errors.code.message}</p>}

        {pricelist?.customColumns.map((col, index) => (
          <Fragment key={index}>
            <label className="text-2xl font-semibold mb-3">{col.name}</label>
            <input
              key={index}
              {...register(`productCustomValues.${index}.value`, {
                required: `${col.name} обязательно`,
              })}
              type={inputType(col.dataType)}
              className={inputClassName}
            />
            {errors.productCustomValues?.[index]?.value && (
              <p className="text-red-500">
                {errors.productCustomValues[index].value?.message}
              </p>
            )}
            <input
              type="hidden"
              {...register(`productCustomValues.${index}.dataType`)}
              value={col.dataType}
            />
          </Fragment>
        ))}

        <Button type={"submit"} buttonText={"Добавить товар"} />
      </form>
    </>
  );
};
