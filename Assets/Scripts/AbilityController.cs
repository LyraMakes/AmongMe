using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public PlayerController playerController;

    public Rigidbody2D rb;

    public bool canSeeGhosts;

    public bool canKill;
    public bool canVent;
    public bool canSabotage;

    public bool canDoTasks;
    public bool canBeKilled;


    public float killRange = 1;
    public float reportRange = 1;
    public float ventRange = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        GameObject target = FindClosestKillable();
        
        // If no target is found, exit
        if (target == null) return;

        Vector3 position = target.transform.position;
        Vector2 targetPos = new Vector2(position.x, position.y);

        PlayerController targetController = target.GetComponent<PlayerController>();

        rb.position = targetPos;

        targetController.killThis();
    }

    private GameObject FindClosestKillable()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("OtherPlayers");
        GameObject closest = null;
        float distance = 3 * 10 * killRange;

        Vector3 position = transform.position;
        var x = gos.Select(x => x.GetComponent<PlayerController>())
            .Where(x => (x.transform.position - position).sqrMagnitude < distance);
        
        
        foreach (GameObject go in gos)
        {
            PlayerController pc = go.GetComponent<PlayerController>();
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            
            if (curDistance < distance && !pc.isDead)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void Report()
    {
        GameObject target = FindClosestDead();
        
        // If no bodies found, return
        if (target == null) return;
        
        PlayerController targetController = target.GetComponent<PlayerController>();
        
        targetController.ressurect();
    }

    GameObject FindClosestDead()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("OtherPlayers");
        GameObject closest = null;
        float distance = 3 * 10 * reportRange;

        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            PlayerController pc = go.GetComponent<PlayerController>();
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && pc.isDead)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void Use()
    {
        GameObject vent = FindClosestVent();

        if (vent != null)
        {
            vent.GetComponent<VentAnimator>().flapTriggered = true;
        }
    }

    GameObject FindClosestVent()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Vents");
        GameObject closest = null;
        float distance = 3 * 10 * ventRange;

        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(30 * reportRange));

        if (canKill)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(30 * killRange));
        }

        if (canVent)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(30 * ventRange));
        }
    }
}
