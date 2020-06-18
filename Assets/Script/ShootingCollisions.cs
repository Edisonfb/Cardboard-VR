using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCollisions : MonoBehaviour
{
    public float damage;

    private void Update()
    {
        Destroy(this, 5 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            Debug.Log("acertou a caixa");
            collision.gameObject.GetComponent<Targets>().TakeDamage(damage);
            Destroy(this);
        }
    }
}
