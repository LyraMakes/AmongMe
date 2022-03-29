using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputController inputController;
    
    public AbilityController abilityController;

    public bool isPlayer;

    public Rigidbody2D rb;

    public AudioSource audioSource;

    public AudioClip deathSound;
    public float deathVol;

    public AudioClip reportSound;
    public float reportVol;

    public float speed;
    public bool goingLeft;
    public bool isDead;
    public bool justDied;
    public bool isGlost;

    public Vector2 movement;

    void Start()
    {
        goingLeft = false;
        isDead = false;
    }


    private void Update()
    {
        if (isPlayer && inputController != null)
        {
            Vector3 currentPosition = transform.position;

            movement = (isDead) ? Vector2.zero : inputController.GetAxies();
            movement.Normalize();

            if (!(movement.x == 0))
            {
                goingLeft = movement.x < 0;
            }

            getCommands();
        }
    }

    void FixedUpdate()
    {
        if (isPlayer)
        {
            rb.MovePosition(rb.position + movement * 10 * speed * Time.fixedDeltaTime);
        }
    }

    private void getCommands()
    {
        //Universal commands
        if (inputController.reportKey())
        {
            abilityController.Report();
        }

        //Imposter Specific commands
        if (inputController.killKey() && abilityController.canKill)
        {
            abilityController.Kill();
        }

        if (inputController.useKey() && abilityController.canVent)
        {
            abilityController.Use();
        }
    }

    public void killThis()
    {
        isDead = !isDead;
        justDied = isDead;

        if (isDead)
        {
            audioSource.PlayOneShot(deathSound, deathVol);
        }
    }

    public void ressurect()
    {
        audioSource.PlayOneShot(reportSound, reportVol);

        isDead = false;
        justDied = false;
    }
}
