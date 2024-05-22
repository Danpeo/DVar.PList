import { ReactNode } from "react";

type HeaderProps = {
  children: ReactNode;
};
export const Header = ({ children }: HeaderProps) => {
  return (
    <>
      <h1 className={"text-5xl font-black text-white mb-4"}>{children}</h1>
    </>
  );
};
