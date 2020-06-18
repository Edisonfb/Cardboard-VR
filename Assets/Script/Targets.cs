using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public float life;

    public GameObject obstacle;

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(obstacle);
            Destroy(this);
        }
    }
}
