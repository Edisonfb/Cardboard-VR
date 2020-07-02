using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject enemyPrefab;

    public int timer;

	private Transform[] spawnPositions;

	private int enemyCount = 0;
	void Start()
	{
		StartCoroutine(DelaySpawn());
		spawnPositions = GetComponentsInChildren<Transform>();
	}


	private IEnumerator DelaySpawn()
	{
		yield return new WaitForSeconds(timer);

		Spawn();
		StartCoroutine(DelaySpawn());
	}

	private void Spawn()
	{
		enemyCount++;
		Vector3 position = spawnPositions[enemyCount % spawnPositions.Length].position;
		Quaternion rotation = enemyPrefab.transform.rotation;
		GameObject enemy = Instantiate(enemyPrefab, position, rotation);
	}

  
}