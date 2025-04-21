import { useLocation } from "react-router-dom";
import { useState } from "react";
import "./NavigateMenuWorkSpace.css";

export default function NavigateMenuWorkSpace({ children }) {
  return (
    <aside className="MenuWorkSpace">
      <h3 className="MenuTitleWorkSpace">Доступные доски</h3>
      {children}
    </aside>
  );
}
