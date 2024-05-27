import { useState, Fragment } from "react";
import { Header } from "../components/Header.tsx";
import { CustomColumn } from "../entities/customColumn.ts";
import { v4 as uuidv4 } from "uuid";
import { DataType } from "../entities/enums/dataType.ts";
import { Button } from "../components/Button.tsx";
import { useForm, useFieldArray } from "react-hook-form";
import { createPricelist } from "../api/pricelists/pricelistApi.ts";
import { CreatePricelistRequest } from "../api/pricelists/requests/createPricelistRequest.ts";
import { BackButton } from "../components/BackButton.tsx";

type Form = {
  name: string;
  customColumns: CustomColumn[];
};

export const AddPricelist = () => {
  const [selectedDataType, setSelectedDataType] = useState<DataType>(
    DataType.Number,
  );
  const [isSuccess, setIsSuccess] = useState(false);

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
    control,
  } = useForm<Form>();

  const { fields, append, remove } = useFieldArray({
    control,
    name: "customColumns",
  });

  const handleAddColumn = () => {
    append({
      id: uuidv4(),
      name: "",
      dataType: selectedDataType,
    });
  };

  const handleRemoveColumn = (index: number) => {
    remove(index);
  };

  const handleDataTypeChange = (index: number, dataType: DataType) => {
    fields[index].dataType = dataType;
    setSelectedDataType(dataType);
  };

  const onSubmit = async (data: Form) => {
    const request: CreatePricelistRequest = {
      name: data.name,
      customColumns: data.customColumns,
    };

    try {
      console.log(JSON.stringify(request));
      await createPricelist(request);
      setIsSuccess(true);
      setTimeout(() => setIsSuccess(false), 3000); 
    } catch (error) {
      console.error(error);
    }
  };

  const inputClassName: string =
    "w-full px-3 py-2 bg-gray-800 border border-gray-900 focus:border-red-500 focus:outline-none focus:bg-gray-800 focus:text-red-500";

  return (
    <>
      <BackButton />
      <Header>Добавление прайс-листа</Header>
      {isSuccess && (
        <p className="text-green-500 mb-4">Прайс-лист успешно добавлен!</p>
      )}
      <form className="max-w-md mx-auto mt-8" onSubmit={handleSubmit(onSubmit)}>
        <label className="text-2xl font-semibold mb-3">
          Название прайс-листа
        </label>
        <input
          {...register("name", {
            required: "Название прайс-листа обязательно",
          })}
          className={inputClassName}
        />
        {errors.name && <p className="text-red-500">{errors.name.message}</p>}
        {fields.map((col, index) => (
          <Fragment key={col.id}>
            <label className="block mb-2">Название колонки</label>
            <input
              type="text"
              className={inputClassName}
              {...register(`customColumns.${index}.name`, {
                required: "Название колонки обязательно",
              })}
            />
            {errors.customColumns?.[index]?.name && (
              <p className="text-red-500">
                {errors.customColumns[index].name?.message}
              </p>
            )}

            <label className="block mb-2" htmlFor={`sub-${index}`}>
              Тип данных
            </label>
            <select
              className={inputClassName}
              value={col.dataType}
              onChange={(e) =>
                handleDataTypeChange(index, parseInt(e.target.value, 10))
              }
            >
              <option value={DataType.Number}>Число</option>
              <option value={DataType.SinglePageText}>
                Одностроничный текст
              </option>
              <option value={DataType.MultiPageText}>
                Многостроничный текст
              </option>
            </select>
          </Fragment>
        ))}
        <Button
          type={"button"}
          buttonText={"+ Добавить колонку"}
          onClick={handleAddColumn}
        />
        {fields.length > 0 && (
          <Button
            type={"button"}
            buttonText={"- Удалить колонку"}
            onClick={() => handleRemoveColumn(fields.length - 1)}
          />
        )}
        <Button type={"submit"} buttonText={"Добавить прайслист"} />
      </form>
    </>
  );
};
