using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused;

    public PlayerInput playerInput;

    [SceneNameDropDown]
    public string mainMenuScene;

    public static GameManager instance;

    public GameObject panelPause;

    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if(ctx.started) {
            isPaused = !isPaused;
            if(isPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        panelPause.SetActive(true);
        //Time.timeScale = 0f;
        playerInput.SwitchCurrentActionMap("UI");
    }

    public void ResumeGame(){
        playerInput.SwitchCurrentActionMap("Gameplay");
        panelPause.SetActive(false);
        //Time.timeScale = 1f;
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void LoadCustomScene(string EscenaCargar)
    {
        SceneManager.LoadScene(EscenaCargar);
    }
}
