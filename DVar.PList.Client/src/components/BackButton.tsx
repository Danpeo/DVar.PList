import { Button } from "./Button.tsx";
import { useNavigate } from "react-router-dom";

export const BackButton = () => {
  const navigate = useNavigate();

  return (
    <>
      <Button type={"button"} buttonText={"НАЗАД"} onClick={() => navigate(-1)} />
    </>
  );
};
