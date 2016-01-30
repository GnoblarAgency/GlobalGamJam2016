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
	private Dictionary <string, Resource> mResources = new Dictionary <string, Resource> ();

	private const float TICK_DELAY = 10f;
	private float mTickTimer;
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
		mTickTimer += Time.deltaTime;

		if (mTickTimer >= TICK_DELAY)
		{
			mTickTimer = 0f;
			UpdateResources ();
		}
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


	#region RESOURCE GROWTH
	/// Applies the growth to the total accumulated resources value.
	void UpdateResources ()
	{
		foreach (Resource r in mResources.Values)
		{
			r.UpdateResourceTotal ();
		}
	}
	#endregion


	#region INITIALIZATION
	void Init ()
	{
		mTickTimer = 0f;
		CreateResourceStore ();
	}

	void CreateResourceStore ()
	{
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
