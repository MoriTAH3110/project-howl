using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle_1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Image _image;
    private Vector3 movimiento;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.color = new Color32(255,255,255,170);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //_rectTransform.anchoredPosition += eventData.delta;
        movimiento = new Vector3(Input.mousePosition.x, transform.position.y ,0f);
        transform.position = movimiento;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.color = new Color(255, 255, 255, 170);
    }

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }
}
