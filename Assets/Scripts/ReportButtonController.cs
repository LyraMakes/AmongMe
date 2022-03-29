using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportButtonController : UIButton
{

    public GameObject player;
    public PlayerController playerController;
    public AbilityController abilityController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        abilityController = player.GetComponent<AbilityController>();
    }

    public override void Activate()
    {
        abilityController.Report(); 
    }
}
