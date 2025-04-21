import { useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import "../../App.css";
import HeaderMain from "./Models/HeaderMain/HeaderMain";
import NavigateMenu from "./Models/NavigateMenu/NavigateMenu";
import Panel from "./Models/Panel/Panel";
import "./Models/NavigateMenu/NavigateMenu.css";
import "./MainPage.css";
import WorkSpaceMini from "./Models/WorkSpaceMini/WorkSpaceMini";
import WorkSpace from "./Models/WorkSpace/WorkSpace";
import { useCallback } from "react";

export default function MainPage() {
  const [workSpaces, setWorkSpaces] = useState([]);
  const navigate = useNavigate();

  const fetchWorkSpaces = useCallback(async () => {
    const response = await fetch("http://localhost:5208/boards", {
      method: "GET",
    });
    const workSpaces = await response.json();
    if (response.status === 200) {
      setWorkSpaces(workSpaces);
    }
  }, []);

  useEffect(() => {
    fetchWorkSpaces();
  }, [fetchWorkSpaces]);

  return (
    <div className="MainPage">
      <HeaderMain />
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

        <Panel>
          {workSpaces.length > 0 ? (
            workSpaces.map((workSpace) => (
              <WorkSpace
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
        </Panel>
      </div>
    </div>
  );
}
