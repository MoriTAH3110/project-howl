using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GamepadUIInput : MonoBehaviour
{
    [Header("PLAYER INPUT")]
    public PlayerInput playerInput;
    public InputActionAsset playerInputAsset;
    public EventSystem eventSystem;
    private InputAction _navigate;

    [Header("GUI")]
    public GameObject lastSelected;

    public GameObject defaultSelected;

    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            eventSystem.SetSelectedGameObject(null);
            ToggleMouseInput(true);
        }
    }

    private void OnEnable()
    {
        lastSelected = defaultSelected;

        playerInputAsset.Enable();

        playerInput.SwitchCurrentActionMap("UI");

        _navigate = playerInputAsset.FindAction("Navigate");
        _navigate.performed += OnUiNavigate;
        _navigate.started += OnUiNavigateStarted;
    }

    private void OnDisable()
    {
        _navigate.performed -= OnUiNavigate;
        _navigate.started -= OnUiNavigateStarted;

        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    private void OnUiNavigateStarted(InputAction.CallbackContext context)
    {
        eventSystem.SetSelectedGameObject(lastSelected ?? defaultSelected);
    }

    private void OnUiNavigate(InputAction.CallbackContext context)
    {
        ToggleMouseInput(false);
        lastSelected = eventSystem.currentSelectedGameObject ?? defaultSelected;
    }

    private void ToggleMouseInput (bool isMouseEnabled) {
        Cursor.visible = isMouseEnabled;
        Cursor.lockState = isMouseEnabled ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
