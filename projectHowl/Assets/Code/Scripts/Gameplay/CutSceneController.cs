using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class CutSceneController : MonoBehaviour
{
    [Header("Video Player")]
    public VideoPlayer cutScene;

    [Header("Scene transition")]
    public GameObject transition;

    [Header("Player input")]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cutScene.Play();
        cutScene.loopPointReached += OnEnd;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnEnd(VideoPlayer source)
    {
        StartCoroutine(FinishCutscene());
    }

    IEnumerator FinishCutscene () {
        transition.SetActive(true);

        player.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);

        cutScene.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        transition.SetActive(false);
    }
}
