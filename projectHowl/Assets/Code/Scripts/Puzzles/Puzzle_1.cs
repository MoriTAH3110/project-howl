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

    //Sombra
    [SerializeField] private GameObject _pieza_faltante;
    public float distancia_exitosa;
    //Scroll
    [SerializeField] private Slider _scroll;
    private Vector3 movimiento;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _pieza_rompecabezas.GetComponent<Image>().color = new Color32(255, 255, 255, 170);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _pieza_rompecabezas.GetComponent<Image>().color = new Color(255, 255, 255, 225);

        float distancia = (_pieza_rompecabezas.transform.position - _pieza_faltante.transform.position).magnitude;
        if (distancia <= distancia_exitosa)
        {
            Debug.Log("Bien hecho perra");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_scroll.value > 0 && _scroll.value < 1)
        {
            movimiento_pieza = new Vector3(Input.mousePosition.x, _pieza_rompecabezas.transform.position.y, 0f);
            _pieza_rompecabezas.transform.position = movimiento_pieza;
        }
    }

    public void SetPiecePosition() {
        _pieza_rompecabezas.GetComponent<RectTransform>().anchoredPosition = new Vector2 (_scroll.value, _pieza_rompecabezas.GetComponent<RectTransform>().anchoredPosition.y);
    }
}
