using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGamepadSupport : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [Header("GUI")]
    public Image selectedIndicator;

    private void OnEnable()
    {
        selectedIndicator.gameObject.SetActive(false);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selectedIndicator.gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        selectedIndicator.gameObject.SetActive(true);
    }
}
