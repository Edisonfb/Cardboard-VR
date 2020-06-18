using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
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
			Target target = collision.collider.GetComponent<Target>();

			target.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
