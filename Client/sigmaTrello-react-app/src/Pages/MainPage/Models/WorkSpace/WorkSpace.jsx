import "./WorkSpace.css";
import logo from "../../../../assets/3613-pepe-with-jesus.png";

export default function WorkSpace({ workSpace, onClick }) {
  return (
    <div className="WorkSpace" onClick={onClick}>
      <div className="WorkSpaceCard">
        <img src={logo} alt="Workspace preview" className="WorkSpaceImage" />
        <div className="Overlay" />
        <div className="WorkSpaceTitle">{workSpace.name}</div>
      </div>
    </div>
  );
}
