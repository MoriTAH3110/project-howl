using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractOnTrigger : MonoBehaviour
{
    [Header("Player Input")]
    public PlayerInput playerInput;
    public InputActionAsset playerInputAsset;
    private InputAction _interactAction;

    [Header("UI")]
    public GameObject interactText;
    public GameObject puzzleUi;

    [Header("Toggle interaction")]
    public bool canInteract = false;
    public bool isCompleted = false;

   private void OnEnable()
   {
        playerInputAsset.Enable();
        playerInput.SwitchCurrentActionMap("Gameplay");
        _interactAction = playerInputAsset.FindAction("Interact");
        _interactAction.started += OnInteract;
   }

   private void OnDisable()
   {
        _interactAction.started -= OnInteract;
        playerInputAsset.Disable();
   }

   private void OnTriggerEnter(Collider other)
   {
        if(other.tag == "Player" & !isCompleted){
            canInteract = true;
            interactText.SetActive(true);
        }
   }

   private void OnTriggerExit(Collider other)
   {
        if(other.tag == "Player"){
            canInteract = false;
            interactText.SetActive(false);
        }
   }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (canInteract) {
            interactText.SetActive(false);
            puzzleUi.SetActive(true);
        }
    }

    public void SetCanInteract (bool _canInteract) {
        canInteract = _canInteract;
    }

    public void SetIsCompleted (bool _isCompleted) {
        isCompleted = _isCompleted;
    }
}
