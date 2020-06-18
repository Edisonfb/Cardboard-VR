using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float life;

	public GameObject obstacle;

	public void TakeDamage(float damage)
	{
		life -= damage;
		if (life <= 0)
		{
			if (obstacle)
			{
				Destroy(obstacle);
			}

			Destroy(gameObject);
		}
	}
}
