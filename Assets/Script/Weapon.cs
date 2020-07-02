using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Projectile projectilePrefab;
    public Transform firePoint;
    private IEnumerator shootCoroutine;

    public float shootDelay = 1.0f;
    public float projectileForce = 1000;
    public int damage = 10;
    public float timer;
    public bool canShoot;

    private void Update()
    {
        timer += Time.deltaTime;
        if (!canShoot)
        {
            return;
        }

        if (timer >= shootDelay)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        Debug.Log("criou tiro");
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //calcular direçao do tiro
        projectile.rb.AddForce(firePoint.forward * projectileForce, ForceMode.Force);
        projectile.damage = damage;
    }

}
