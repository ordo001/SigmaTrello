import { useLocation, useNavigate } from "react-router-dom";
import { useState } from "react";
//import "../../../../App.css";
import logo from "../../../../assets/3613-pepe-with-jesus.png";
import { FaSearch, FaQuestionCircle } from "react-icons/fa";

export default function HeaderWorkSpace() {
  const navigate = useNavigate();
  return (
    <header className="Header">
      <div className="header-left">
        <img
          src={logo}
          alt="Logo"
          className="logo"
          onClick={() => {
            navigate("/");
          }}
        />
        <h3 className="NameApp">SigmaTrello</h3>
      </div>

      <nav className="header-center">
        <ul className="nav-links">
          <li>Профиль</li>
          <li>Выйти</li>
        </ul>
      </nav>

      <div className="header-right">
        <div className="search-box">
          <FaSearch className="search-icon" />
          <input type="text" className="search-input" placeholder="Поиск" />
        </div>
        <FaQuestionCircle className="help-icon" />
        <img src={logo} alt="Avatar" className="avatar" />
      </div>
    </header>
  );
}
