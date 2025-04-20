import { useLocation, useNavigate } from "react-router-dom";
import { useState, useCallback, useEffect } from "react";
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
  const [workSpaces, setWorkSpaces] = useState([]);
  const navigate = useNavigate();

  const fetchWorkSpaces = useCallback(async () => {
    const response = await fetch("http://localhost:5208/Boards", {
      method: "GET",
    });
    const workSpaces = await response.json();
    if (response.status === 200) setWorkSpaces(workSpaces);

    // console.log(workSpaces);
  }, []);

  useEffect(() => {
    fetchWorkSpaces();
  }, [fetchWorkSpaces]);

  return (
    <div className="WorkSpacePage">
      <HeaderWorkSpace />
      <div className="MainContent">
        <NavigateMenu>
          {workSpaces.length > 0 ? (
            workSpaces.map((workSpace) => (
              <WorkSpaceMini
                workSpace={workSpace}
                onClick={() => navigate("/b/" + workSpace.id)}
                key={workSpace.id}
              />
            ))
          ) : (
            <p
              style={{
                textAlign: "center",
                fontSize: "24px",
                marginTop: "20px",
              }}
            >
              Досок нет
            </p>
          )}
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
