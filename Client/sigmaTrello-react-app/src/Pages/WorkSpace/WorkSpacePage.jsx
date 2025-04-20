import { useLocation } from "react-router-dom";
import { useState } from "react";
import "../../App.css";
import "./WorkSpacePage.css";
import HeaderWorkSpace from "./Models/HeaderWorkSpace/HeaderWorkSpace";
import NavigateMenu from "../MainPage/Models/NavigateMenu/NavigateMenu";
import WorkSpaceMini from "../MainPage/Models/WorkSpaceMini/WorkSpaceMini";
import Panel from "../MainPage/Models/Panel/Panel";
import Section from "./Models/Section/Section";
import PanelWorkSpace from "./Models/PanelWorkSpace/PanelWorkSpace";
import Card from "./Models/Card/Card";
export default function WorkSpacePage() {
  return (
    <div className="WorkSpacePage">
      <HeaderWorkSpace />
      <div className="MainContent">
        <NavigateMenu>
          <WorkSpaceMini />
          <WorkSpaceMini />
          <WorkSpaceMini />
        </NavigateMenu>

        <PanelWorkSpace>
          <Section>
            <Card title="Сделать адаптив" />
            <Card title="Исправить баг с полоской" />
            <Card title="Добавить скролл" />
            <Card title="Загрузить аватарку" />
          </Section>
          <Section />
          <Section />
          <Section />
          <Section />
        </PanelWorkSpace>
      </div>
    </div>
  );
}
