using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadUIInput : MonoBehaviour
{
    public InputAction playerUIInput;
    public PlayerInput playerInput;

    [SerializeField]
    public GameObject lastSelected;

    public Canvas[] sceneCanvas;

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null) {
            lastSelected = EventSystem.current.currentSelectedGameObject;
        }

        //Mouse input detected
        if((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) & playerInput.currentActionMap.name == "UI") {
            //Enable mouse when moved
            ToggleMouseInput(true);

            //Set selected to mouse position
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            EventSystem.current.SetSelectedGameObject(pointerEventData.pointerCurrentRaycast.gameObject);
        }
    }

    private void OnEnable()
    {
        playerUIInput.started += OnNavigateStarted;
        playerUIInput.canceled += OnNavigateCanceled;
        playerUIInput.Enable();
    }

    private void OnDisable()
    {
        playerUIInput.started -= OnNavigateStarted;
        playerUIInput.canceled -= OnNavigateCanceled;
        playerUIInput.Disable();
    }

    private void OnNavigateStarted(InputAction.CallbackContext context)
    {
        if(playerInput.currentControlScheme == "UI") {
            EventSystem.current.SetSelectedGameObject(lastSelected.gameObject);
        }

        //Disable mouse when gamepad input is started
        ToggleMouseInput(false);
    }

    private void OnNavigateCanceled(InputAction.CallbackContext context)
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
    }

    private void ToggleMouseInput (bool isMouseEnabled) {
        Cursor.visible = isMouseEnabled;
        Cursor.lockState = isMouseEnabled ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
}
