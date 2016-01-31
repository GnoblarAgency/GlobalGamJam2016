﻿using UnityEngine;
using System.Collections;

/// Holds all buildings in the current scene
public class BuildingsCache : MonoBehaviour
{

	#region PROPERTIES
	public static BuildingManager Instance { get; private set; }
	#endregion


	#region VARIABLES
	public GameObject temple;
	Vector3 templePosition;

	Barracks[] barracks;
	int barracksIdx = 0;

	Farm[] farms;
	int farmsIdx = 0;

	House[] houses;
	int housesIdx = 0;

	Monument[] monuments;
	int monumentsIdx = 0;

	Prison[] prisons;
	int prisonsIdx = 0;
	#endregion


	#region UNITY EVENTS
	void Start ()
	{
		templePosition = temple.transform.position;

		//find all buildings in scene
		barracks = FindObjectsOfType <Barracks> ();
		farms = FindObjectsOfType <Farm> ();
		houses = FindObjectsOfType <House> ();
		monuments = FindObjectsOfType <Monument> ();
		prisons = FindObjectsOfType <Prison> ();

		SortBuildings ();
	}
	#endregion


	#region PUBLIC API
	public void BuyBarracks()
	{
		barracks[barracksIdx].gameObject.SetActive (true);
		barracksIdx++;
	}
	public void BuyFarm()
	{
		farms[farmsIdx].gameObject.SetActive (true);
		farmsIdx++;
	}
	public void BuyHouse()
	{
		houses[housesIdx].gameObject.SetActive (true);
		housesIdx++;
	}
	public void BuyMonument()
	{
		monuments[monumentsIdx].gameObject.SetActive (true);
		monumentsIdx++;
	}
	public void BuyPrison()
	{
		prisons[prisonsIdx].gameObject.SetActive (true);
		prisonsIdx++;
	}
	#endregion


	#region HELPERS
	/// Sorts all buildings by distance from temple.
	void SortBuildings ()
	{
		for (int i = 0 ; i < barracks.Length ; i++)
		{
			for (int j = 0 ; j < barracks.Length ; j++)
			{
				if (GetDistanceToTemple (barracks[i].transform.position) < GetDistanceToTemple(barracks[j + 1].transform.position))
				{
					Barracks tempVar = barracks [j + 1];
					barracks [j + 1] = barracks [i];
					barracks [i] = tempVar;
				}
			}
		}
			
		for (int i = 0 ; i < farms.Length ; i++)
		{
			for (int j = 0 ; j < farms.Length ; j++)
			{
				if (GetDistanceToTemple (farms[i].transform.position) < GetDistanceToTemple(farms[j + 1].transform.position))
				{
					Farm tempVar = farms [j + 1];
					farms [j + 1] = farms [i];
					farms [i] = tempVar;
				}
			}
		}
			
		for (int i = 0 ; i < houses.Length ; i++)
		{
			for (int j = 0 ; j < houses.Length ; j++)
			{
				if (GetDistanceToTemple (houses[i].transform.position) < GetDistanceToTemple(houses[j + 1].transform.position))
				{
					House tempVar = houses [j + 1];
					houses [j + 1] = houses [i];
					houses [i] = tempVar;
				}
			}
		}
			
		for (int i = 0 ; i < monuments.Length ; i++)
		{
			for (int j = 0 ; j < monuments.Length ; j++)
			{
				if (GetDistanceToTemple (monuments[i].transform.position) < GetDistanceToTemple(monuments[j + 1].transform.position))
				{
					Monument tempVar = monuments [j + 1];
					monuments [j + 1] = monuments [i];
					monuments [i] = tempVar;
				}
			}
		}

		for (int i = 0 ; i < prisons.Length ; i++)
		{
			for (int j = 0 ; j < prisons.Length ; j++)
			{
				if (GetDistanceToTemple (prisons[i].transform.position) < GetDistanceToTemple(prisons[j + 1].transform.position))
				{
					Prison tempVar = prisons [j + 1];
					prisons [j + 1] = prisons [i];
					prisons [i] = tempVar;
				}
			}
		}

	}

	float GetDistanceToTemple (Vector3 position)
	{
		return Vector3.Distance (templePosition, position);
	}
	#endregion
}