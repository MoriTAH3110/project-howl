using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Puzzle1_Gamepad : MonoBehaviour
{
    [Header("PUZZLE")]
    [SerializeField] private Image _puzzlePiece;
    [SerializeField] private Image _puzzleSpace;
    [SerializeField] private GameObject _successStamp;
    [SerializeField] private GameObject _puzzleCanvas;
    public float successDistance;
    public float successTime;
    private float _remainingTime;
    private bool isCompleted = false;

    [Header("UI")]
    public Slider slider;

    [Header("INPUT")]
    public PlayerInput playerInput;
    public InputActionAsset playerInputAsset;
    private InputAction _analogNavAction, _interact;
    public float sensitivity;
    private int _joystickInput;

    void Update()
    {
        slider.value += (_joystickInput * sensitivity * Time.deltaTime);

        bool isSuccess = Mathf.Abs(_puzzlePiece.GetComponent<RectTransform>().anchoredPosition.x - _puzzleSpace.GetComponent<RectTransform>().anchoredPosition.x) <= successDistance;

        if (isSuccess) {
            if(_remainingTime >= 0f) {
                _remainingTime -= Time.deltaTime;
            } else {
                StartCoroutine(OnSuccess());
            }
        } else {
            _remainingTime = successTime;
        }
        
    }

    private void OnEnable()
    {
        playerInputAsset.Enable();
        playerInput.SwitchCurrentActionMap("UI");

        _analogNavAction = playerInputAsset.FindAction("AnalogNavigate");
        _analogNavAction.performed += OnStickHold;
        _analogNavAction.canceled += OnStickRelase;

        _interact = playerInputAsset.FindAction("Interact");
        _interact.performed += OnPushInteract;


        _remainingTime = successTime;
    }

    private void OnPushInteract(InputAction.CallbackContext context)
    {
        _puzzleCanvas.SetActive(!_puzzleCanvas.activeInHierarchy);
    }

    private void OnStickHold(InputAction.CallbackContext context)
    {
        if(!isCompleted) {
            _puzzlePiece.color = new Color32(255, 255, 255, 170);
            _joystickInput = Mathf.FloorToInt(context.ReadValue<Vector2>().x);
        }
    }

    private void OnStickRelase(InputAction.CallbackContext context)
    {
        _puzzlePiece.color = new Color32(255, 255, 255, 255);
        _joystickInput = 0;
    }

    private void OnDisable()
    {
        _analogNavAction.performed -= OnStickHold;
        _analogNavAction.canceled -= OnStickRelase;

        _interact.performed -= OnPushInteract;

        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    private IEnumerator OnSuccess() {
        yield return null;

        _successStamp.SetActive(true);
        isCompleted = true;
        slider.interactable = false;

        yield return new WaitForSeconds(1.0f);

        _puzzleCanvas.SetActive(false);
    }

    
    public void SetPiecePosition() {
        _puzzlePiece.GetComponent<RectTransform>().anchoredPosition = new Vector2 (slider.value, _puzzlePiece.GetComponent<RectTransform>().anchoredPosition.y);
    }
    
}
