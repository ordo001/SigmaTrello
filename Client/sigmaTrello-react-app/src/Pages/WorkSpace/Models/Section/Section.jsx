import "./Section.css";
export default function Section({ children, section }) {
  return (
    <div className="Section">
      <div className="SectionHeader">{section.name}</div>
      <div className="CardList">{children}</div>
    </div>
  );
}
