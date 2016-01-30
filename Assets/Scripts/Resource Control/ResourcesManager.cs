using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class ResourcesManager : MonoBehaviour
{

	#region PUBLIC EVENTS
	public static event Action OnTick = delegate {};
	#endregion

	#region PROPERTIES
	public static ResourcesManager instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	public const float TICK_DELAY = 10f;
	#endregion


	#region PRIVATE VARIABLES
	private StatisticsEngine mStatsEngine;
	private Dictionary <ResourceType, Resource> mResources = new Dictionary <ResourceType, Resource> ();


	private float mTickTimer;
	#endregion


	#region UNITY EVENTS
	void Awake()
	{
		if (instance == null)
		{
			instance = this;

			Init();
		}
		else
		{
			Debug.LogError("There is more than one ResourcesManager in the scene!");
		}
	}

	void Update () 
	{
		mTickTimer += Time.deltaTime;

		if (mTickTimer >= TICK_DELAY)
		{
			mTickTimer = 0f;


			UpdateResources ();
			PopulationAssignment.instance.UpdatePopulationAssignment();
			mStatsEngine.UpdateStats ();
		
			PeopleSpawner.instance.CheckSpawn(GetResourcePopulation().TotalAmount);
			//event
			OnTick ();
		}
	}
	#endregion


	#region PUBLIC_FACING API
	public void ApplyModifier (ResourceGrowthModifier modifier)
	{
		mResources[modifier.resourceType].ApplyModifier(modifier);
	}

	public void RemoveModifier (ResourceGrowthModifier modifier)
	{
		mResources[modifier.resourceType].RemoveModifier(modifier);
	}


	public Resource GetResourceFood ()
	{
		return mResources[ResourceType.Food];
	}

	public Resource GetResourceHappiness ()
	{
		return mResources[ResourceType.Happiness];
	}

	public Resource GetResourcePopulation ()
	{
		return mResources[ResourceType.Population];
	}

	public Resource GetResourcePrisoners ()
	{
		return mResources[ResourceType.Prisoners];
	}

	public Resource GetResourceFavour ()
	{
		return mResources[ResourceType.Favour];
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

		mStatsEngine = new StatisticsEngine ();
	}

	void CreateResourceStore ()
	{
		Resource food = new FoodResource ();
		Resource happiness = new HappinessResource ();
		Resource population = new PopulationResource ();
		Resource prisoners = new PrisonersResource ();
		Resource favour = new FavourResource ();

		mResources.Add (ResourceType.Food, food);
		mResources.Add (ResourceType.Happiness, happiness);
		mResources.Add (ResourceType.Population, population);
		mResources.Add (ResourceType.Prisoners, prisoners);
		mResources.Add (ResourceType.Favour, favour);
	}
	#endregion
}
