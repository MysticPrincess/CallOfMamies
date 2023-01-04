using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsHit : MonoBehaviour
{
    public Animator animator;
    public GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        animator.SetTrigger("isEating");
        gameController.score += 1;
        Destroy(other.gameObject);
        Debug.Log(gameController.score);
    }
}
