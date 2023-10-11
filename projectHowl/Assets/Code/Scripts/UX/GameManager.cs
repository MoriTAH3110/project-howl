using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panelPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPause()
    {
        PausarJuego();
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true); 
    }
    public void DespausarJuego()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }
    public void VolverMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void CargarEscena()
    {

    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
