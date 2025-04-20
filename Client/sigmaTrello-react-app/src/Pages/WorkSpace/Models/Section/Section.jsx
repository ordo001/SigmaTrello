import "./Section.css";
export default function Section({ children }) {
  return (
    <div className="Section">
      <div className="SectionHeader">SectionHeader</div>
      <div className="CardList">{children}</div>
    </div>
  );
}
