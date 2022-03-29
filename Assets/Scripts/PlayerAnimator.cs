using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public PlayerController playerController;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", playerController.movement.magnitude * playerController.speed);

        spriteRenderer.flipX = playerController.goingLeft && !playerController.isDead;


        animator.SetBool("isDead", playerController.isDead);
        animator.SetBool("isFlopping", playerController.justDied);
        playerController.justDied = false;
    }
}