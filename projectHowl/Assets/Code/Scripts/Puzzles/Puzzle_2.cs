using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_2 : MonoBehaviour
{
    [SerializeField] public Slider _scroll_1;
    [SerializeField] public Slider _scroll_2;
    [SerializeField] public Slider _scroll_3;

    private Slider _scroll_seleccionado;
    private float mov_slider_velocidad = 0.002f;

    private float sliderValue;
    private bool subiendo = true;
    private bool pararSlicer = false;
    private void Start()
    {
        _scroll_1.value = 0;
        _scroll_2.value = 0;
        _scroll_3.value = 0;
        _scroll_seleccionado = _scroll_1;
    }
    private void Update()
    {
        sliderValue = _scroll_seleccionado.value;

        ContinuacionValidacionSlider();
        if (!pararSlicer)
        {
            ValidacionSlider();
        }

        _scroll_seleccionado.value = sliderValue;
    }
    private void ContinuacionValidacionSlider() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && (sliderValue < 0.6f && sliderValue > 0.4f))
        {
            if (_scroll_seleccionado == _scroll_1)
            {
                _scroll_seleccionado = _scroll_2;
                sliderValue = _scroll_seleccionado.value;
                mov_slider_velocidad = 0.004f;
            }
            else 
            {
                if(_scroll_seleccionado == _scroll_2)
                {
                    _scroll_seleccionado = _scroll_3;
                    sliderValue = _scroll_seleccionado.value;
                    mov_slider_velocidad = 0.006f;
                }else
                { 
                    pararSlicer = true; 
                    //Aqui va lo que pasa después de haberlo logrado
                }
                
            }

        }
    }
    private void ValidacionSlider()
    {
        if (_scroll_seleccionado.value < 1 && subiendo)
            SubirSlider();
        else
        {
            subiendo = false;
            BajarSlider();
            if (_scroll_seleccionado.value <= 0)
            {
                subiendo = true;
            }
        }
    }
    private void SubirSlider()
    {
        sliderValue += mov_slider_velocidad;
    }
    private void BajarSlider()
    {
        sliderValue -= mov_slider_velocidad;
    }
}
