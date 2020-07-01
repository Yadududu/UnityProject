#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace RLD
{
    public abstract class DragAndDropHandler
    {
        public void Handle(Event dragAndDropEvent, Rect dropAreaRectangle)
        {
            switch (dragAndDropEvent.type)
            {
                case UnityEngine.EventType.DragUpdated:

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    break;

                case UnityEngine.EventType.DragPerform:

                    if (dropAreaRectangle.Contains(dragAndDropEvent.mousePosition) &&
                        dragAndDropEvent.type == UnityEngine.EventType.DragPerform) PerformDrop();
                    break;
            }
        }

        protected abstract void PerformDrop();
    }
}
#endif