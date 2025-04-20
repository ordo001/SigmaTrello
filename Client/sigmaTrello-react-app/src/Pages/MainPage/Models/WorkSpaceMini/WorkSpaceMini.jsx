import "./WorkSpaceMini.css";
import logo from "../../../../assets/3613-pepe-with-jesus.png";

export default function WorkSpaceMini({ workSpace, onClick }) {
  return (
    <div className="WorkSpaceMini" onClick={onClick}>
      <img src={logo} alt="Avatar" className="WorkSpaceMiniImage" />
      <p className="Name">{workSpace.name}</p>
    </div>
  );
}
