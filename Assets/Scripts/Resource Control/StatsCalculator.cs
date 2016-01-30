using UnityEngine;
using System.Collections;

/// The brain of the resource system. Calculates the current growth values for
public class StatsCalculator 
{
	// Happiness is determined by the balance of the other resources.

	// Low happiness = -Pop growth
	// High happiness = +Pop growth

	// High food growth = +Happiness
	// X people = X food ; if surplus food, +Pop growth

	#region RESOURCES
	//our resource types, laid out here for easy-peasy referency goodness
	FoodResource food;
	FavourResource favour;
	PrisonersResource prisoners;
	PopulationResource population;
	HappinessResource happiness;
	#endregion


	#region RESOURCE MODIFIERS
	ResourceModifier foodModifier;
	ResourceModifier favourModifier;
	ResourceModifier prisonersModifier;
	ResourceModifier populationModifier;
	ResourceModifier happinessModifier;
	#endregion


	public StatsCalculator ()
	{
		//get our references
		food = (FoodResource)ResourcesManager.instance.GetResourceFood ();
		favour = (FavourResource)ResourcesManager.instance.GetResourceFavour ();
		prisoners = (PrisonersResource)ResourcesManager.instance.GetResourcePrisoners ();
		population = (PopulationResource)ResourcesManager.instance.GetResourcePopulation ();
		happiness = (HappinessResource)ResourcesManager.instance.GetResourceHappiness ();

		//create blank modifiers modifiers
		foodModifier = new ResourceModifier (ResourceNames.FOOD, 0);
		favourModifier = new ResourceModifier (ResourceNames.FAVOUR, 0);
		prisonersModifier = new ResourceModifier (ResourceNames.PRISONERS, 0);
		populationModifier = new ResourceModifier (ResourceNames.POPULATION, 0);
		happinessModifier = new ResourceModifier (ResourceNames.HAPPINESS, 0);

		//add these to the respective resources so that we can affect the growth rates
		food.ApplyModifier (foodModifier);
		favour.ApplyModifier (favourModifier);
		prisoners.ApplyModifier (prisonersModifier);
		population.ApplyModifier (populationModifier);
		happiness.ApplyModifier (happinessModifier);
	}

	public void UpdateStats ()
	{
		CalculatePopulationFood ();
	}

	void CalculatePopulationFood ()
	{
		float remainder = food.TotalAmount - population.TotalAmount;

		//food is consumed by populous
		food.RemoveAmount (population.TotalAmount);

		//if there wasn't enough food
		if (remainder < 0)
		{
			population.RemoveAmount (remainder);
		}

		

		//food.RemoveAmount ();
		//populationModifier.Value = food.TotalAmount / 2;
	}
}
