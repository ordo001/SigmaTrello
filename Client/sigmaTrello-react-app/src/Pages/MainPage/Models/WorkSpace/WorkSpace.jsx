import "./WorkSpace.css";
import logo from "../../../../assets/3613-pepe-with-jesus.png";

export default function WorkSpace() {
  return (
    <div className="WorkSpace">
      <div className="WorkSpaceCard">
        <img src={logo} alt="Workspace preview" className="WorkSpaceImage" />
        <div className="Overlay" />
        <div className="WorkSpaceTitle">Название доски</div>
      </div>
    </div>
  );
}
