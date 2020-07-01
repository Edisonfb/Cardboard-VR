using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public Projectile projectilePrefab;
	public Transform positionPrefab;
	private IEnumerator shootCoroutine;

	public bool canShoot = false;
	public float shootDelay = 1.0f;
	public float projectileForce = 500;
	public float damage;

	public void EnterShoot()
	{
		shootCoroutine = ShootTimer();
		StartCoroutine(shootCoroutine);
	}

	public void ExitShoot()
	{
		StopCoroutine(shootCoroutine);
	}

	private IEnumerator ShootTimer()
	{
		yield return new WaitForSeconds(shootDelay);

		Shoot();
		StartCoroutine(shootCoroutine);
	}

	private void Shoot()
	{
		Debug.Log("criou tiro");
		Projectile projectile = Instantiate(projectilePrefab, positionPrefab.position, positionPrefab.rotation);
		//calcular direçao do tiro
		projectile.rb.AddForce(Camera.main.transform.forward * projectileForce, ForceMode.Force);
		projectile.damage = damage;
	}

}
