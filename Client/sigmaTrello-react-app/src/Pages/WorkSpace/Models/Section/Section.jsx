import Card from "../Card/Card";
import "./Section.css";
export default function Section({ section }) {
  return (
    <div className="Section">
      <div className="SectionHeader">{section.name}</div>
      <div className="CardList">
        {section.cards && section.cards.length > 0 ? (
          section.cards.map((card) => <Card card={card} />)
        ) : (
          <div className="EmptyCards">Нет карточек</div>
        )}
      </div>
    </div>
  );
}
