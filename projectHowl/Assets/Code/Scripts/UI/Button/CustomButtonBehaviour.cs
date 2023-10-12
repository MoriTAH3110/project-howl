using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButtonBehaviour : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    // ANIMATION STATES
    static class ButtonStates
    {
        public static readonly string Normal = "Normal";
        public static readonly string Highlighted = "Highlighted";
        public static readonly string Pressed = "Pressed";
        public static readonly string Selected = "Selected";
        public static readonly string Disabled = "Disabled";
    }

    Animator buttonAnimator;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        button.onClick.AddListener(onClickHandler);
    }

    private void Update()
    {

    }

    #region COMMON CONTROLS
    public void onClickHandler()
    {
        //The user has click with the mouse or has pressed the action button on the keyboard / gamepad
        if (button.interactable)
        {
            buttonAnimator.Play(ButtonStates.Pressed, 0, 0f);
        }
    }
    #endregion

    #region GAMEPAD OR KEYBOARD CONTROLS
    public void OnSelect(BaseEventData eventData)
    {
        //The user is on this button but has not press it
        if (button.interactable) { buttonAnimator.Play(ButtonStates.Selected, 0, 0f); }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //The user is no longer on this button
        if (button.interactable) { buttonAnimator.Play(ButtonStates.Normal, 0, 0f); }
    }
    #endregion

    #region MOUSE CONTROLS
    public void OnPointerEnter(PointerEventData eventData)
    {
        //The mouse is hovering over the button but is not clicked
        if (button.interactable) { buttonAnimator.Play(ButtonStates.Selected, 0, 0f); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //The mouse is no longer hovering over the button
        if (button.interactable) { buttonAnimator.Play(ButtonStates.Normal, 0, 0f); }
    }
    #endregion

}
