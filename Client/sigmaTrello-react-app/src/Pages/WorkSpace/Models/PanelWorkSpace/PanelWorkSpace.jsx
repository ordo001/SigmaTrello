import { DragDropContext, Droppable, Draggable } from "react-beautiful-dnd";
import "./PanelWorkSpace.css";
import Section from "../Section/Section";
import { useState } from "react";
import { useLocation } from "react-router-dom";

export default function PanelWorkSpace({
  sections = [],
  setSections,
  onReorder,
}) {
  const [creating, setCreating] = useState(false);
  const [newSectionName, setNewSectionName] = useState("");
  const location = useLocation();

  const workSpaceId = location.pathname.split("/")[2];

  const handleDragEnd = (result) => {
    if (!result.destination) return;

    const sourceIndex = result.source.index;
    const destinationIndex = result.destination.index;

    const reordered = Array.from(sections);
    const [movedSection] = reordered.splice(sourceIndex, 1);
    reordered.splice(destinationIndex, 0, movedSection);

    const updatedSections = reordered.map((section, index) => ({
      ...section,
      position: index,
    }));

    setSections(updatedSections);
    onReorder(updatedSections);
  };

  const handleCreateSection = async () => {
    var maxIndex = Math.max(...sections.map((s) => s.position));
    var position = sections.length > 0 ? maxIndex + 1 : 0;

    const response = await fetch(
      `http://localhost:5208/boards/${workSpaceId}/sections`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          name: newSectionName,
          position: position,
        }),
      }
    );

    if (response.ok) {
      const createdSection = await response.json();
      setSections([...sections, createdSection]);
      setNewSectionName("");
      setCreating(false);
    }
  };

  const handleTextareaChange = (e) => {
    e.target.style.height = "auto";
    e.target.style.height = e.target.scrollHeight + "px";
    setNewSectionName(e.target.value);
  };

  return (
    <DragDropContext onDragEnd={handleDragEnd}>
      <Droppable
        droppableId="sections"
        direction="horizontal"
        isDropDisabled={false}
        isCombineEnabled={false}
        ignoreContainerClipping={true}
      >
        {(provided) => (
          <div
            className="PanelWorkSpace"
            ref={provided.innerRef}
            {...provided.droppableProps}
          >
            {sections.map((section, index) => (
              <Draggable
                key={section.id}
                draggableId={section.id.toString()}
                index={index}
              >
                {(provided) => (
                  <div
                    className="SectionWrapper"
                    ref={provided.innerRef}
                    {...provided.draggableProps}
                    {...provided.dragHandleProps}
                  >
                    <Section section={section} />
                  </div>
                )}
              </Draggable>
            ))}

            {provided.placeholder}

            {/* типа компонент создания секции */}
            <div className="CreateSectionWrapper">
              {creating ? (
                <div className="CreateSection">
                  <textarea
                    type="text"
                    value={newSectionName}
                    onChange={handleTextareaChange}
                    placeholder="Название секции"
                    className="SectionInput"
                  />
                  <div className="CreateSectionActions">
                    <button
                      onClick={
                        newSectionName.length > 0 ? handleCreateSection : null
                      }
                      className="CreateSectionButton"
                    >
                      Создать
                    </button>
                    <button
                      onClick={() => {
                        setCreating(false);
                        setNewSectionName("");
                      }}
                    >
                      ✕
                    </button>
                  </div>
                </div>
              ) : (
                <button
                  className="AddSectionButton"
                  onClick={() => setCreating(true)}
                >
                  + Добавить новую секцию
                </button>
              )}
            </div>
          </div>
        )}
      </Droppable>
    </DragDropContext>
  );
}
