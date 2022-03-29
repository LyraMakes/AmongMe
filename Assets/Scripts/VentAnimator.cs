using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VentAnimator : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Animator animator;

    public bool flapTriggered;

    [SerializeField]
    private float pitch = 1.0f;

    [SerializeField]
    public AudioClip flapOpen;

    public AudioMixer mixer;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("flap", flapTriggered);

        mixer.SetFloat("ventPitch", pitch);
    }

    public void triggerFlap()
    {
        flapTriggered = false;

        pitch = getRandPitch();

        audioSource.PlayOneShot(flapOpen, 1.0f);
    }

    private float getRandPitch()
    {
        return 0.9f + Random.Range(0.0f, 20f / 100f);
    }
}
