using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorTransition : MonoBehaviour
{
    public Animator animator;

    public LevelLoader levelLoader;

    public playerController playerController;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.gameObject.transform.SetParent(this.transform);
            StartCoroutine(OnElevatorTransition()); 
        }
    }

    IEnumerator OnElevatorTransition() {
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("onElevatorUp", true);
        playerController.enabled = playerInput.enabled = false;

        yield return new WaitForSeconds(1);

        levelLoader.LoadNextLevel();
    }

}
