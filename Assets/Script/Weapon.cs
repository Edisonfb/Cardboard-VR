using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    IEnumerator shootCoroutine;
    public bool canShoot = false;
    public float shootDelay = 1.0f;


    public GameObject bullet;
    public Transform positionPrefab;
    public float speedBullet = 500;

    public void EnterShoot()
    {
        Debug.Log("entrou");
        shootCoroutine = ShootTimer();
        StartCoroutine(shootCoroutine);
    }

    public void ExitShoot()
    {
        Debug.Log("saiu");
        StopCoroutine(shootCoroutine);
    }

   IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(shootDelay);
        
        Debug.Log("está rodando essa bagaça");
        Shoot();
        StartCoroutine(shootCoroutine);

        //yield return null;
        
       
    }

    void Shoot()
    {
        Debug.Log("criou tiro");
        GameObject aux = Instantiate(bullet, positionPrefab.position, positionPrefab.rotation);
        //calcular direçao do tiro
        aux.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * speedBullet, ForceMode.Force);
    }
}
