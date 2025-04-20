import { useLocation } from "react-router-dom";
import { useState } from "react";
import "../../App.css";
import HeaderMain from "./Models/HeaderMain/HeaderMain";
import NavigateMenu from "./Models/NavigateMenu/NavigateMenu";
import Panel from "./Models/Panel/Panel";
import "./Models/NavigateMenu/NavigateMenu.css";
import "./MainPage.css";
import WorkSpaceMini from "./Models/WorkSpaceMini/WorkSpaceMini";
import WorkSpace from "./Models/WorkSpace/WorkSpace";

export default function MainPage() {
  return (
    <div className="MainPage">
      <HeaderMain />
      <div className="MainContent">
        <NavigateMenu>
          <WorkSpaceMini />
          <WorkSpaceMini />
          <WorkSpaceMini />
        </NavigateMenu>

        <Panel>
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          <WorkSpace />
          {/* <WorkSpace /> */}
        </Panel>
      </div>
    </div>
  );
}
