using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    IEnumerator shootCoroutine;
    public bool canShoot = false;
    public float shootDelay = 1.0f;

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
        StartCoroutine(ShootTimer());

        //yield return null;
        
       
    }

    void Shoot()
    {

    }
}
