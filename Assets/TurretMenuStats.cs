using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretMenuStats : MonoBehaviour
{
    //Z prefabu bierzemy wyswietlane statystyki wie¿y
    public GameObject prefabTurret;
    public Turret turret;

    public int damageMin;
    public int damageMax;
    public string weapon;
    public int price;
    public float range;
    public float fireRate;
    public string towerName;

    void Start()
    {
        turret = prefabTurret.GetComponent<Turret>();
        damageMin = turret.minDamage;
        damageMax = turret.maxDamage;
        weapon = turret.weapon;
        price = turret.price;
        range = turret.range;
        fireRate = turret.fireRate;
        towerName = turret.towerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
