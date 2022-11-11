using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject turretStat;
    public GameObject turretMenu;
    private bool showMenu;
    void Start()
    {
        turretMenu.gameObject.SetActive(false);
        turretStat.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu()
    {
        turretMenu.gameObject.SetActive(true);
    }
}
