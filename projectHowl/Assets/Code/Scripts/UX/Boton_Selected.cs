using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Boton_Selected : MonoBehaviour, IPointerEnterHandler// required interface when using the OnPointerEnter method.
{
    public Animator animator;
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("presionado", true);
        //animator.SetBool("mantener", true);
        Debug.Log("1");
    }
}