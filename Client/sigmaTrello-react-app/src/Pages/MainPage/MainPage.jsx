import { useLocation } from "react-router-dom";
import { useState } from "react";
import "../../App.css";
import HeaderMain from "./Models/HeaderMain/HeaderMain";
import NavigateMenu from "./Models/NavigateMenu/NavigateMenu";
import Panel from "./Models/Panel/Panel";
import "./Models/NavigateMenu/NavigateMenu.css";
import "./MainPage.css";

export default function MainPage() {
  return (
    <div className="MainPage">
      <HeaderMain />
      <div className="MainContent">
        <NavigateMenu />
        <Panel />
      </div>
    </div>
  );
}
