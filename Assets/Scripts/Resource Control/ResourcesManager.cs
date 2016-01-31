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
	//this will result in a 2min30 period
	public const float TICK_DELAY = 10f;
	public const int TICK_COUNT_FOR_PERIOD = 1;	
	#endregion


	#region PRIVATE VARIABLES
	private StatisticsEngine mStatsEngine;
	private Dictionary <ResourceType, Resource> mResources = new Dictionary <ResourceType, Resource> ();


	private float mTickTimer;
	private float mTicks;
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

		if (mTickTimer >= 1)
		{
			mTickTimer = 0f;
			mTicks++;

			UpdateResources_Increment ();
			GodManager.Instance.UpdateGodFavours (TICK_DELAY);
			PopulationAssignment.instance.UpdatePopulationAssignment();


			PeopleSpawner.instance.CheckSpawn(GetResourcePopulation().TotalAmount);
		}

		if (mTicks >= TICK_DELAY)
		{
			mTicks = 0;

			mStatsEngine.UpdateStats ();
			GodManager.Instance.CheckDivineJudgement();
			OnTick ();	

			/*mTickTimer = 0f;

			UpdateResources_Tick ();
			PopulationAssignment.instance.UpdatePopulationAssignment();
			mStatsEngine.UpdateStats ();
		
			PeopleSpawner.instance.CheckSpawn(GetResourcePopulation().TotalAmount);
			*/

			//event

		}
	}
	#endregion


	#region RESOURCE GROWTH
	/// Applies a fraction of growth to the total accumulated resources values of all resources.
	/// Is a smaller, incremental update
	void UpdateResources_Increment ()
	{
		foreach (Resource r in mResources.Values)
		{
			r.UpdateResourceTotal (TICK_DELAY);
		}
	}

	/// Applies all growth to the total accumulated resources values of all resources. 
	/// Is singular, large update
	void UpdateResources_Tick ()
	{
		foreach (Resource r in mResources.Values)
		{
			r.UpdateResourceTotal ();
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

		mResources.Add (ResourceType.Food, food);
		mResources.Add (ResourceType.Happiness, happiness);
		mResources.Add (ResourceType.Population, population);
		mResources.Add (ResourceType.Prisoners, prisoners);
	}
	#endregion
}
