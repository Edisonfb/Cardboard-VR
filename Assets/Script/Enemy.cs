using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{

	//Vector3 targetPosition;
	public int health = 100;

	NavMeshAgent agent;

	void Start()
	{
		//targetPosition = Player.Instance.transform.position;
		agent = GetComponent<NavMeshAgent>();

		EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener((data) =>
		{
            Debug.Log("entrou");
			Player.Instance.leftWeapon.canShoot = true;
			Player.Instance.rightWeapon.canShoot = true;
		});

		EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = EventTriggerType.PointerExit;
		entry2.callback.AddListener((data) =>
		{
            Debug.Log("saiu");
			Player.Instance.leftWeapon.canShoot = false;
			Player.Instance.rightWeapon.canShoot = false;
		});

		trigger.triggers.Add(entry);
		trigger.triggers.Add(entry2);
	}

	void Update()
	{

		Vector3 targetPosition = Player.Instance.transform.position;
		agent.SetDestination(targetPosition);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
            Player.Instance.leftWeapon.canShoot = false;
            Player.Instance.rightWeapon.canShoot = false;
			Destroy(gameObject);
        }
	}
}
