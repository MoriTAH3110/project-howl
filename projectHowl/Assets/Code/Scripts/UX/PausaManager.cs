using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaManager : MonoBehaviour
{
    public static PausaManager instance;
    public bool IsPaused { get; private set; }
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }
    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        //InputManager.p
    }
    public void UnPauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }
}
