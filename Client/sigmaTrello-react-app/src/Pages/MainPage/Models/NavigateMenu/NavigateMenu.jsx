import { useLocation } from "react-router-dom";
import { useState } from "react";
import "./NavigateMenu.css";
import WorkSpaceMini from "../WorkSpaceMini/WorkSpaceMini";

export default function NavigateMenu({ children }) {
  return (
    <aside className="Menu">
      <h3 className="MenuTitle">Доступные доски</h3>
      {children}
    </aside>
  );
}
