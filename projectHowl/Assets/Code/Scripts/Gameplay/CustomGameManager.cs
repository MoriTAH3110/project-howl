using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGameManager : MonoBehaviour
{
    public PlayerInput playerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
    }
}
