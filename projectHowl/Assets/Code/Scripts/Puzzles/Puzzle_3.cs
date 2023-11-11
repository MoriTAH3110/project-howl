using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle_3 : MonoBehaviour
{
    public Button[] buttons; // Botones asignados desde el editor
    public TMP_Text textDisplay;

    private int dificultadSecuencia = 3;
    private int inicioSecuencia = 0;

    private int[] sequence;
    private int sequenceIndex;
    private bool playerTurn;

    void Start()
    {
        sequence = new int[6]; // Inicializar la secuencia con el tamaño adecuado
        playerTurn = false;
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
        textDisplay.text = "Valor actual: " + value;
    }

    IEnumerator IluminarBotonSecuencia()
    {
        for (int i = 0; i < dificultadSecuencia; i++)
        {

            yield return new WaitForSeconds(1.0f); // Tiempo entre cada botón iluminado
            textDisplay.enabled = true; // Esto mostrará el objeto TMP_Text
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
                    }

                    playerTurn = false;
                }
            }
            else
            {
                // El jugador se equivocó, podrías reiniciar el juego o mostrar un mensaje de error
                Debug.Log("Perdió");
                playerTurn = false;
                sequenceIndex = 0;
                StartCoroutine(IluminarBotonSecuencia());
                // Iniciar nuevo juego, por ejemplo
            }
        }
    }
}
