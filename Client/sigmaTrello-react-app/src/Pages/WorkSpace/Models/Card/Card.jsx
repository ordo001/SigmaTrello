import "./Card.css";
export default function Card({ card }) {
  return (
    <div className="Card">
      <div className="CardTitle">{card.name}</div>
    </div>
  );
}
