using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle_3 : MonoBehaviour
{
    public Button[] buttons; // Botones asignados desde el editor
    public TMP_Text textDisplay;
    public TMP_Text textTurnos;

    private int dificultadSecuencia = 3;
    private int inicioSecuencia = 0;

    private int[] sequence;
    private int sequenceIndex;
    private bool playerTurn;

    void Start()
    {
        sequence = new int[6]; // Inicializar la secuencia con el tamaño adecuado
        playerTurn = false;
        textTurnos.text = "Observa";
        RellenarSecuenciaDeArray();
        StartCoroutine(IluminarBotonSecuencia());
    }
    void Update()
    {

    }
    void RellenarSecuenciaDeArray()
    {
        // Generar una nueva secuencia
        for (int i = inicioSecuencia; i < dificultadSecuencia; i++)
        {
            sequence[i] = Random.Range(0, 4); // Generar números para los botones
            //Debug.Log("secuencia:" + sequence[i]);
        }
    }
    void UpdateTextDisplay(int value)
    {
        switch (value)
        {
            case 0:
                textDisplay.text = "ROJO";
                textDisplay.color = new Color(0xB0 / 255.0f, 0x48 / 255.0f, 0x48 / 255.0f, 1.0f); // Establece el color del texto a #B04848;
                break;
            case 1:
                textDisplay.text = "AZUL";
                textDisplay.color = new Color(0x8A / 255.0f, 0xB9 / 255.0f, 0xDA / 255.0f, 1.0f); // Establece el color del texto a #8AB9DA
                break;
            case 2:
                textDisplay.text = "AMARILLO";
                textDisplay.color = new Color(0xD9 / 255.0f, 0xC4 / 255.0f, 0x73 / 255.0f, 1.0f); // Establece el color del texto a #D9C473
                break;
            case 3:
                textDisplay.text = "VERDE";
                textDisplay.color = new Color(0xA1 / 255.0f, 0xD9 / 255.0f, 0x89 / 255.0f, 1.0f); // Establece el color del texto a #A1D989
                break;
        }
        
    }

    IEnumerator IluminarBotonSecuencia()
    {
        for (int i = 0; i < dificultadSecuencia; i++)
        {

            yield return new WaitForSeconds(1.0f); // Tiempo entre cada botón iluminado
            textDisplay.enabled = true; // Esto mostrará el objeto TMP_Text
            textTurnos.text = "Observa";
            int buttonIndex = sequence[i];
            UpdateTextDisplay(sequence[i]);
            //Button buttonToHighlight = buttons[buttonIndex];

            //ColorBlock colors = buttonToHighlight.colors;
            //colors.normalColor = Color.yellow; // Cambiar el color a amarillo para simular iluminación
            //buttonToHighlight.colors = colors;

            yield return new WaitForSeconds(0.5f);
            textDisplay.enabled = false; // Esto ocultará el objeto TMP_Text
            //colors.normalColor = Color.white; // Cambiar de vuelta al color original
            //buttonToHighlight.colors = colors;
        }

        playerTurn = true;
        textTurnos.text = "Tu turno";
    }
    public void OnButtonClicked(int buttonIndex)
    {
        if (playerTurn)
        {
            if (buttonIndex == sequence[sequenceIndex])
            {
                sequenceIndex++;
                if (sequenceIndex >= dificultadSecuencia)
                {
                    // El jugador completó la secuencia correctamente, inicia la siguiente ronda
                    Debug.Log("Ganó");
                    sequenceIndex = 0;
                    if (dificultadSecuencia < 5)
                    {
                        inicioSecuencia = dificultadSecuencia;
                        dificultadSecuencia++;
                        RellenarSecuenciaDeArray();
                        StartCoroutine(IluminarBotonSecuencia());
                    }
                    else
                    {
                        Debug.Log("Ganó COMPLETAMENTE");
                        //AQUI VA CUANDO YA SE COMPLETA EL NIVEL COMPLETAMENTE
                    }

                    playerTurn = false;
                }
            }
            else
            {
                Debug.Log("Perdió");
                playerTurn = false;
                sequenceIndex = 0;
                StartCoroutine(IluminarBotonSecuencia());
            }
        }
    }
}
