using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Puzzle_1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //Rompecabezas
    [SerializeField] private GameObject _pieza_rompecabezas;
    private Vector3 movimiento_pieza;

    //Scroll
    [SerializeField] private Slider _scroll;
    private Vector3 movimiento;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _pieza_rompecabezas.GetComponent<Image>().color = new Color32(255, 255, 255, 170);
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (_scroll.value >= 0 && _scroll.value <= 1)
    //    {
    //        movimiento_pieza = new Vector3(Input.mousePosition.x, _pieza_rompecabezas.transform.position.y, 0f);
    //        _pieza_rompecabezas.transform.position = movimiento_pieza;
    //    }
    //}

    public void OnEndDrag(PointerEventData eventData)
    {
        _pieza_rompecabezas.GetComponent<Image>().color = new Color(255, 255, 255, 225);
    }
    void Start()
    {
        //OnSliderValueChanged(_scroll.value);
    }
    //private void Update()
    //{
    //    OnSliderValueChanged(_scroll.value);
    //}
    //public void OnSliderValueChanged(float value)
    //{
    //    if (value >= 0 && value <= 10070)
    //    {
    //        movimiento_pieza = new Vector3(value, _pieza_rompecabezas.transform.position.y, 0f);
    //        _pieza_rompecabezas.transform.position = movimiento_pieza;
    //    }
    //}
    public void OnDrag(PointerEventData eventData)
    {
        if (_scroll.value > 0 && _scroll.value < 1)
        {
            movimiento_pieza = new Vector3(Input.mousePosition.x, _pieza_rompecabezas.transform.position.y, 0f);
            _pieza_rompecabezas.transform.position = movimiento_pieza;
        }
    }
}
