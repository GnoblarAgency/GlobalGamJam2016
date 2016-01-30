using UnityEngine;
using System.Collections;

public class PeopleSpawner : MonoBehaviour 
{
	public GameObject[] people;
	public Transform[] spawnPoints;

	public static PeopleSpawner instance;


	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			SpawnPerson();
		}
	}

	public void SpawnPerson()
	{
		Transform point = spawnPoints[Random.Range(0,spawnPoints.Length)];
		GameObject person = people[Random.Range(0,people.Length)];

		GameObject.Instantiate(person,point.position,point.rotation);
	}
	
}
