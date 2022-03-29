using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMaterial : MonoBehaviour
{
    public GameObject go;
    public Material material;

    public Color bodyColor;
    public Color bodyShade;




    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        material = go.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetColor("_BodyColor", bodyColor);
        material.SetColor("_BodyShade", bodyShade);
    }
}
