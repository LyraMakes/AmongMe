using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public PlayerController playerController;
    public AudioSource audioSource;

    public AudioClip[] footSteps;


    AudioClip getStep()
    {
        int rInt = Random.Range(0, footSteps.Length - 1);
        return footSteps[rInt];
    }

    public void playFootstep()
    {
        audioSource.PlayOneShot(getStep(), 1.0f);
    }
}
