using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_3 : MonoBehaviour
{
    public Button[] buttons; // Botones asignados desde el editor
    private int dificultadSecuencia = 4;
    private int inicioSecuencia = 0;
    private int[] sequence;
    private int sequenceIndex;
    private bool playerTurn;

    void Start()
    {
        sequence = new int[6]; // Inicializar la secuencia con el tama�o adecuado
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
            sequence[i] = Random.Range(0, dificultadSecuencia); // Generar n�meros para los botones
            Debug.Log(sequence[i]);
        }
    }
    IEnumerator IluminarBotonSecuencia()
    {
        for (int i = inicioSecuencia; i < dificultadSecuencia; i++)
        {
            Debug.Log("entra1");
            yield return new WaitForSeconds(1.0f); // Tiempo entre cada bot�n iluminado
            int buttonIndex = sequence[i];
            Button buttonToHighlight = buttons[buttonIndex];
            ColorBlock colors = buttonToHighlight.colors;
            colors.normalColor = Color.yellow; // Cambiar el color a amarillo para simular iluminaci�n
            buttonToHighlight.colors = colors;
            yield return new WaitForSeconds(0.5f);
            colors.normalColor = Color.white; // Cambiar de vuelta al color original
            buttonToHighlight.colors = colors;
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
                    // El jugador complet� la secuencia correctamente, inicia la siguiente ronda
                    Debug.Log("Gan�");
                }
            }
            else
            {
                // El jugador se equivoc�, podr�as reiniciar el juego o mostrar un mensaje de error
                Debug.Log("Perdi�");
                // Iniciar nuevo juego, por ejemplo
            }
        }
    }
}
