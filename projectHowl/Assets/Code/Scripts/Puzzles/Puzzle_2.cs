using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_2 : MonoBehaviour
{
    [SerializeField] public Slider _scroll_1;

    private float sliderValue;
    private bool subiendo = true;
    private bool pararSlicer = false;
    private void Start()
    {
        _scroll_1.value = 0;
    }
    private void Update()
    {
        sliderValue = _scroll_1.value;

        ContinuacionValidacionSlider();
        if (!pararSlicer)
        {
            ValidacionSlider();
        }
        
        _scroll_1.value = sliderValue;
    }
    private void ContinuacionValidacionSlider() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && (sliderValue < 0.7f && sliderValue > 0.4))
        {
            pararSlicer = true;
        }
    }
    private void ValidacionSlider()
    {
        if (_scroll_1.value < 1 && subiendo)
            SubirSlider();
        else
        {
            subiendo = false;
            BajarSlider();
            if (_scroll_1.value <= 0)
            {
                subiendo = true;
            }
        }
    }
    private void SubirSlider()
    {
        sliderValue += 0.005f;
    }
    private void BajarSlider()
    {
        sliderValue -= 0.005f;
    }
}
