using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiMenuManager : MonoBehaviour
{
    public Button firstSelectedButton;

    bool hasRunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
    }

    private void OnEnable()
    {
        if(!hasRunOnce) {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
            hasRunOnce = true;
        }
    }

    private void OnDisable()
    {
        hasRunOnce = false;
    }
}
