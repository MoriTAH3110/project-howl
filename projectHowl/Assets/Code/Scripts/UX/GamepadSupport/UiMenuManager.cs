using UnityEngine;
using UnityEngine.EventSystems;

public class UiMenuManager : MonoBehaviour
{
    public GameObject firstSelected;
    bool hasRunOnce = false;

    private void OnEnable()
    {
        if(!hasRunOnce) {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
            hasRunOnce = true;
        }
    }

    private void OnDisable()
    {
        hasRunOnce = false;
    }
}
