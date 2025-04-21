import { DragDropContext, Droppable, Draggable } from "react-beautiful-dnd";
import "./PanelWorkSpace.css";
import Section from "../Section/Section";

export default function PanelWorkSpace({
  sections = [],
  setSections,
  onReorder,
}) {
  const handleDragEnd = (result) => {
    if (!result.destination) return;

    const reordered = Array.from(sections);
    const [moved] = reordered.splice(result.source.index, 1);
    reordered.splice(result.destination.index, 0, moved);

    const updated = reordered.map((sec, index) => ({
      ...sec,
      position: index,
    }));

    setSections(updated);
    onReorder(updated);
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
          </div>
        )}
      </Droppable>
    </DragDropContext>
  );
}
