using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public Transform head;
    public float turnSpeed = 10f;
    private Transform firePoint;

    [Header("TowerProperties")]
    private float fireCountdown;
    public float fireRate = 1;
    public float range = 3f;
    public int minDamage = 1;
    public int maxDamage = 3;
    public int price;
    public string towerName;
    public string weapon;

    public GameObject bulletPrefab;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        firePoint = head.GetChild(0);
    }

    // Update is called once per frame
     void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(head.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        head.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
