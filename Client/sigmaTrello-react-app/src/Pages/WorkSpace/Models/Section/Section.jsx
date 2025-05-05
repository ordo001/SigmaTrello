import Card from "../Card/Card";
import "./Section.css";
import { useState, useRef, useEffect } from "react";

export default function Section({ section }) {
  const [menuOpen, setMenuOpen] = useState(false);
  const menuRef = useRef(null);

  const toggleMenu = () => {
    setMenuOpen((prev) => !prev);
  };

  // Закрытие меню при клике вне его
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (menuRef.current && !menuRef.current.contains(event.target)) {
        setMenuOpen(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  return (
    <div className="Section">
      <div className="SectionHeader">
        <div className="SectionName">{section.name}</div>
        <div className="SectionMenuToggle" onClick={toggleMenu}>
          ⋯
          {menuOpen && (
            <div className="SectionMenuDropdown" ref={menuRef}>
              <div className="DropdownItem">Переименовать</div>
              <div className="DropdownItem">Удалить</div>
            </div>
          )}
        </div>
      </div>

      <div className="CardList">
        {section.cards?.length > 0 ? (
          section.cards.map((card) => <Card key={card.id} card={card} />)
        ) : (
          <div className="EmptyCards">Нет карточек</div>
        )}
      </div>
    </div>
  );
}
