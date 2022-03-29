
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillButtonController : UIButton
{
    private SpriteRenderer sr;

    public GameObject player;
    public PlayerController playerController;
    public AbilityController abilityController;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        abilityController = player.GetComponent<AbilityController>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.enabled = abilityController.canKill;
    }

    public override void Activate()
    {
        abilityController.Kill();
    }
}
