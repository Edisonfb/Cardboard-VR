using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public bool stop;

	private Transform target;
	private int pointIndex;

	public static Player Instance;

	public Weapon leftWeapon;
	public Weapon rightWeapon;

	private void Start()
	{
		Instance = this;
		stop = false;
		pointIndex = 0;
		target = FollowPath.points[0];
		transform.position = target.position;
	}


	private void Update()
	{
		if (stop == false)
		{
			Vector3 dir = target.position - transform.position;
			transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

			//Quaternion carRotation = Quaternion.LookRotation(dir);
			//transform.rotation = Quaternion.Lerp(transform.rotation, carRotation, 10 * Time.deltaTime);

			if (Vector3.Distance(transform.position, target.position) <= 0.5f)
			{
				GetNextPoint();
			}
		}
	}

	private void GetNextPoint()
	{
		if (pointIndex >= FollowPath.points.Length - 1)
		{
			stop = true;
		}
		else
		{
			target = FollowPath.points[++pointIndex];
		}
	}
}
