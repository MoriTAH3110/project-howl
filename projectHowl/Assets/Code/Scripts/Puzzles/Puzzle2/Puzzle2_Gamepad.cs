using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Puzzle2_Gamepad : MonoBehaviour
{
    public GameObject puzzle2Ui;

    [Header("Gamepad Input")]
    public PlayerInput playerInput;
    public InputActionAsset playerInputAsset;
    public bool isActionPressed;
    private InputAction _action, _interact;

    private void OnEnable()
    {
        playerInputAsset.Enable();
        playerInput.SwitchCurrentActionMap("Puzzle2");

        _interact = playerInputAsset.FindAction("Interact");
        _interact.performed += OnInteract;

        _action = playerInputAsset.FindAction("Action");


    }

    private void OnDisable()
    {
        _interact.performed -= OnInteract;

        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    private void Update()
    {
        if(_action.triggered) {
            isActionPressed = true;
        } else {
            isActionPressed = false;
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        puzzle2Ui.SetActive(false);
    }
}
