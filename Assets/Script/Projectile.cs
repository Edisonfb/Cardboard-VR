using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage = 10;
	public Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		Destroy(gameObject, 5);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Target"))
		{
			Enemy enemy = collision.collider.GetComponent<Enemy>();

			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
