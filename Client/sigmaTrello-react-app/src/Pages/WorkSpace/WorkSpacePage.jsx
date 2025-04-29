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
import NavigateMenuWorkSpace from "./Models/NavigateMenuWorkSpace/NavigateMenuWorkSpace";

export default function WorkSpacePage() {
  const [workSpaces, setWorkSpaces] = useState([]);
  const [sections, setSections] = useState([]);
  const [currentWorkSpace, setCurrentWorkSpace] = useState();
  const navigate = useNavigate();
  const location = useLocation();

  const workSpaceId = location.pathname.split("/")[2];

  useEffect(() => {
    const fetchWorkSpaces = async () => {
      const response = await fetch("http://localhost:5208/Boards");
      const data = await response.json();

      if (response.status === 200) {
        setWorkSpaces(data);
      }
    };

    fetchWorkSpaces();
  }, []);

  useEffect(() => {
    if (workSpaces.length === 0) return;

    const found = workSpaces.find((x) => x.id.toString() === workSpaceId);

    setCurrentWorkSpace(found);
  }, [workSpaces, workSpaceId]);

  useEffect(() => {
    if (!currentWorkSpace?.id) return;

    const fetchSections = async () => {
      const response = await fetch(
        `http://localhost:5208/boards/${currentWorkSpace.id}/sections`
      );
      const data = await response.json();

      if (response.status === 200) {
        setSections(data);
      }
    };
    // console.log(sections);
    fetchSections();
  }, [currentWorkSpace]);

  const handleSectionReorder = async (updatedSections) => {
    try {
      await Promise.all(
        updatedSections.map((section) =>
          fetch(`http://localhost:5208/sections/${section.id}`, {
            method: "PATCH",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(section.position),
          }).then((response) => {
            if (!response.ok) {
              return response.text().then((text) => {
                throw new Error(`Ошибка для секции ${section.id}: ${text}`);
              });
            }
          })
        )
      );
    } catch (error) {
      console.error("Произошла ошибка при обновлении секций:", error.message);
    }
  };

  return (
    <div className="WorkSpacePage">
      <HeaderWorkSpace />
      <div className="MainContent">
        <NavigateMenuWorkSpace>
          {workSpaces.length > 0 ? (
            workSpaces.map((workSpace) => (
              <WorkSpaceMini
                workSpace={workSpace}
                onClick={() => navigate("/b/" + workSpace.id)}
                key={workSpace.id}
              />
            ))
          ) : (
            <p className="no-boards">Досок нет</p>
          )}
        </NavigateMenuWorkSpace>
        <PanelWorkSpace
          sections={sections}
          setSections={setSections}
          onReorder={handleSectionReorder}
        />
      </div>
    </div>
  );
}
