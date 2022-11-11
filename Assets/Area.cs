using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Color startColor;
    public Vector3 offset;
    public Color hoverColor;
    private Renderer rend;
    private GameObject turret;
    private Shop shop;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
    }
    private void OnMouseDown()
    {
       if(turret != null)
        {
            return;
        }
        //GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        //turret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);
        shop.ShowMenu();
        
        

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
