using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ResourcesManager : MonoBehaviour
{

	#region PROPERTIES
	public static ResourcesManager instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PRIVATE VARIABLES
	Dictionary <string, Resource> mResources = new Dictionary <string, Resource> ();
	#endregion


	#region UNITY EVENTS
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("There is more than one ResourcesManager in the scene!");
		}
	}

	void Start () 
	{
		Init ();
	}

	void Update () 
	{
	
	}
	#endregion


	#region PUBLIC_FACING API
	public void ApplyModifier (ResourceModifier modifier)
	{
		mResources[modifier.Name].ApplyModifier(modifier.Value);
	}

	public void RemoveModifier (ResourceModifier modifier)
	{
		mResources[modifier.Name].RemoveModifier(modifier.Value);
	}

	public Resource GetResourceFood ()
	{
		return mResources[ResourceNames.FOOD];
	}

	public Resource GetResourceHappiness ()
	{
		return mResources[ResourceNames.HAPPINESS];
	}

	public Resource GetResourcePopulation ()
	{
		return mResources[ResourceNames.POPULATION];
	}

	public Resource GetResourcePrisoners ()
	{
		return mResources[ResourceNames.PRISONERS];
	}
	#endregion


	#region INITIALIZATION
	void Init ()
	{
		CreateResourceStore ();
	}

	void CreateResourceStore ()
	{

		Debug.Log ("Creating store");
		Resource food = new FoodResource ();
		Resource happiness = new HappinessResource ();
		Resource population = new PopulationResource ();
		Resource prisoners = new PrisonersResource ();

		mResources.Add (food.DisplayName, food);
		mResources.Add (happiness.DisplayName, happiness);
		mResources.Add (population.DisplayName, population);
		mResources.Add (prisoners.DisplayName, prisoners);
	}
	#endregion
}
