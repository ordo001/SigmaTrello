import "./WorkSpaceMini.css";
import logo from "../../../../assets/3613-pepe-with-jesus.png";

export default function WorkSpaceMini() {
  return (
    <div className="WorkSpaceMini">
      <img src={logo} alt="Avatar" className="WorkSpaceMiniImage" />
      <p className="Name">WorkSpaceMiniName</p>
    </div>
  );
}
