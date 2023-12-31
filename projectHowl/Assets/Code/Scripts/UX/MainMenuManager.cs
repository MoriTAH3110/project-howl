using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SceneNameDropDown]
    public string playButtonScene;

    public void OnPlayBtnClick() {
    SceneManager.LoadScene(playButtonScene);
   }

   public void OnQuitClick(){
    Debug.Log("Quitting app!");
    Application.Quit();
   }
}
