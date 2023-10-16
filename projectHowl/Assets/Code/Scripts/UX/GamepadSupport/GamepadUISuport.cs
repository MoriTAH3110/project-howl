using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GamepadUISuport : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [System.Serializable]
    public class PointerEvent : UnityEvent<PointerEventData> {}

    public PointerEvent buttonSelectEvent;
    public PointerEvent buttonDeselectEvent;

    public void OnSelect(BaseEventData eventData)
    {
        buttonSelectEvent.Invoke(null);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        buttonDeselectEvent.Invoke(null);
    }
}
