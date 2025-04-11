import { useLocation } from "react-router-dom";
import { useState } from "react";
import "../App.css";
import useAuth from "../Func/useAuth";

//Получить id с url
const getIdWorkSpace = () => {
  const location = useLocation();
  const id = location.pathname.split("/")[2];
  return id;
};

export default function Login() {
  return <>id: {getIdWorkSpace()}</>;
}
