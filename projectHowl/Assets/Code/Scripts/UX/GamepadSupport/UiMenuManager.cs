using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiMenuManager : MonoBehaviour
{
    public Button firstSelectedButton;
    public EventSystem eventSystem;

    bool hasRunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if(!hasRunOnce) {
            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
            hasRunOnce = true;
        }
    }

    private void OnDisable()
    {
        hasRunOnce = false;
    }
}
