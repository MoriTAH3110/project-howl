using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Puzzle_2 : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public Slider _scroll_1;
    [SerializeField] public Slider _scroll_2;
    [SerializeField] public Slider _scroll_3;
    [SerializeField] public GameObject successStamp;
    [SerializeField] public GameObject puzzle2Ui;


    [Header("Gamepad support")]
    public Puzzle2_Gamepad gamepadInput;

    [Header("On Sucess")]
    public UnityEvent WhenCompleted;

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
        if ((Input.GetKeyDown(KeyCode.Space) || gamepadInput.isActionPressed) && (sliderValue < 0.6f && sliderValue > 0.4f))
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
                    OnSuccess();
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

    public void OnSuccess() {
        StartCoroutine(ShowSuccessStamp());
    }

    private IEnumerator ShowSuccessStamp() {
        yield return new WaitForSeconds(1.0f);
        successStamp.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        puzzle2Ui.SetActive(false);

        WhenCompleted.Invoke();
    }
}
