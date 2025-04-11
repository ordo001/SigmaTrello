import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import useAuth from "./Func/useAuth";
import Login from "./Pages/Login";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainPage from "./Pages/MainPage/MainPage";

function App() {
  //const [count, setCount] = useState(0);
  //const { isAuthenticated } = useAuth();

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/mainPage" element={<MainPage />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
