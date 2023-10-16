using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadUIInput : MonoBehaviour
{
    public InputAction playerUIInput;

    [SerializeField]
    public Button lastSelected;

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null) {
            lastSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        }

        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            EventSystem.current.SetSelectedGameObject(pointerEventData.pointerCurrentRaycast.gameObject);
        }
    }

    private void OnEnable()
    {
        playerUIInput.Enable();
        playerUIInput.started += OnNavigateStarted;
        playerUIInput.canceled += OnNavigateCanceled;
    }

    private void OnDisable()
    {
        playerUIInput.Disable();
        playerUIInput.started -= OnNavigateStarted;
        playerUIInput.canceled -= OnNavigateCanceled;
    }

    private void OnNavigateStarted(InputAction.CallbackContext context)
    {
        EventSystem.current.SetSelectedGameObject(lastSelected.gameObject);
    }

    private void OnNavigateCanceled(InputAction.CallbackContext context)
    {
        lastSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
    }
    
}
