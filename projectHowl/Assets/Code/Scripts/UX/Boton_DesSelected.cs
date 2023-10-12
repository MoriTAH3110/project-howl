using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Boton_DesSelected : MonoBehaviour, IPointerExitHandler// required interface when using the OnPointerExit method.
{
    //Do this when the cursor exits the rect area of this selectable UI object.
    public Animator animator;
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("The cursor exited the selectable UI element.");
        animator.SetBool("mantener", false);
        animator.SetBool("aparecer", false);
    }
}