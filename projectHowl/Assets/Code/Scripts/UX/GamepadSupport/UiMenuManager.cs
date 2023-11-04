using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
