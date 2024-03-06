using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SceneNameDropDown]
    public string nextLevel;

    [SerializeField]
    Animator transition;

    public void LoadNextLevel() {
        StartCoroutine(LoadWithTransition(nextLevel));
    }

    IEnumerator LoadWithTransition(string _nextScene) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(_nextScene);
    }
}
