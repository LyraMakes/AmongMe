using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string killHotkey = "q";
    public string reportHotkey = "r";
    public string useHotkey = "e";
    public string useTwo = "space";
    public string mapHotkey = "tab";

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetAxies()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool killKey()
    {
        return Input.GetKeyDown(killHotkey);
    }

    public bool reportKey()
    {
        return Input.GetKeyDown(reportHotkey);
    }

    public bool useKey()
    {
        return Input.GetKeyDown(useHotkey) || Input.GetKeyDown(useTwo);
    }

    public bool mapKey()
    {
        return Input.GetKeyDown(mapHotkey);
    }
}
