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

	//our resource types, laid out here for easy-peasy referency goodness
	FoodResource food;
	PopulationResource population;
	PrisonersResource prisoners;

	HappinessResource happiness;

	public StatsCalculator ()
	{
		
	}

	public void UpdateStats ()
	{
		
	}
}
