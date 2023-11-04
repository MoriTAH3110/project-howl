using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionTrigger : MonoBehaviour
{
    public PlayerInput playerInput;
    public GameObject puzzleUI;
    public GameObject instructionCanvas;

    private bool canInteract = false;

    private void TogglePuzzleUi(bool isUiActive) {
       puzzleUI.SetActive(isUiActive);
    }

    public void OnInteract(InputAction.CallbackContext ctx) {
        if (canInteract & ctx.performed) {
            TogglePuzzleUi(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            canInteract = true;
            instructionCanvas.SetActive(canInteract);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            canInteract = false;
            instructionCanvas.SetActive(canInteract);
        }
    }
}
