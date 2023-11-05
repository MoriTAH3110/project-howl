using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject playerGameObject;

    [Header("ANIMATION")]
    public Animator playerAnimator;

    [Header("PLAYER CONTROLLERS")]
    public PlayerInput playerInput;
    public playerController playerController;
    public InputActionAsset playerInputAsset;
    private InputAction _move, _jump;
    private float  playerYSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerYSpeed = Mathf.RoundToInt(playerGameObject.GetComponent<Rigidbody>().velocity.y) >= 0 ? 1.0f : -1.0f;

        if ( !playerController.isGrounded() ) {
            playerAnimator.SetFloat("ySpeed", playerYSpeed);
        }
        
    }

    private void Update()
    {
        if (!playerController.isGrounded()) {
            playerAnimator.SetBool("isMoving", false);
            playerAnimator.SetBool("isJumping", true);
        } else {
            playerAnimator.SetBool("isJumping", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float moveDirection = Mathf.Clamp(context.ReadValue<float>(), -1.0f, 1.0f);

        if (moveDirection == 1.0f) {
            playerGameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else if (moveDirection == -1.0f) {
            playerGameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (context.performed) {
            playerAnimator.SetBool("isMoving", true);
        } else {
            playerAnimator.SetBool("isMoving", false);
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (context.started) {
            playerAnimator.SetBool("isJumping", true);
        }
    }

}
