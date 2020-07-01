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

	public void EnterShoot()
	{
		Debug.Log("enter");
		shootCoroutine = ShootTimer();
		StartCoroutine(shootCoroutine);
	}

	public void ExitShoot()
	{
		Debug.Log("exit");
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
		Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
		//calcular direçao do tiro
		projectile.rb.AddForce(firePoint.forward * projectileForce, ForceMode.Force);
		projectile.damage = damage;
	}

}
