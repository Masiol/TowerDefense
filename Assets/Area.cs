using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
