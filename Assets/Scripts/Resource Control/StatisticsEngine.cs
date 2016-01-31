using UnityEngine;
using System.Collections;

/// The brain of the resource system. Calculates the current growth values for
public class StatisticsEngine 
{

	#region RESOURCES
	//our resource types, laid out here for easy-peasy referency goodness
	FoodResource food;
	FavourResource favour;
	PrisonersResource prisoners;
	PopulationResource population;
	HappinessResource happiness;
	#endregion


	#region RESOURCE MODIFIERS
	//these are our modifiers for each resource.
	//NOTE that these are just the modifiers we control based on our main resource cycle.
	//The other modifiers (blessing / god effects / ...) are not changed and are still in effect!
	ResourceGrowthModifier foodModifier;
	ResourceGrowthModifier favourModifier;
	ResourceGrowthModifier prisonersModifier;
	ResourceGrowthModifier populationModifier;
	ResourceGrowthModifier happinessModifier;
	#endregion


	public StatisticsEngine ()
	{
		//get our references
		food = (FoodResource)ResourcesManager.instance.GetResourceFood ();
		prisoners = (PrisonersResource)ResourcesManager.instance.GetResourcePrisoners ();
		population = (PopulationResource)ResourcesManager.instance.GetResourcePopulation ();
		happiness = (HappinessResource)ResourcesManager.instance.GetResourceHappiness ();

		//create blank modifiers modifiers
		foodModifier = new ResourceGrowthModifier (ResourceType.Food, 0);
		prisonersModifier = new ResourceGrowthModifier (ResourceType.Prisoners, 0);
		populationModifier = new ResourceGrowthModifier (ResourceType.Population, 0);
		happinessModifier = new ResourceGrowthModifier (ResourceType.Happiness, 0);

		//add these to the respective resources so that we can affect the growth rates
		food.ApplyModifier (foodModifier);
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
		//Food is consumed by populous. 2 food per person per update. 
		//If we have shortage of food:
		//		The number of people who cannot be fed die.
		//		Population growth is affected by 1/2 the number of food units that we are short of.
		//		Happiness and happiness growth is lowered by the percentage of the population who died.
		//If we have a surplus of food:
		// 		Population growth is increased by half the amount of surplus food units
		//		Happiness and happiness growth is increased by the percentage of surplus food compared to population


		float remainder = food.TotalAmount - (population.TotalAmount * 2);
		food.RemoveAmount (population.TotalAmount);

		bool tooLittleFood = remainder < 0 ? true : false;

		remainder = Mathf.Abs (remainder);
		float percentOfFoodToPop = (remainder / population.TotalAmount) * 100;

		//kill off populous and reverse growth, decrease happiness and reverse growth.
		if (tooLittleFood)
		{
			//people with no food die
			population.RemoveAmount ( remainder );

			//affect growth by 1/2 amount of deaths
			populationModifier.value = - (remainder / 2);

			//happiness.RemoveAmount ( percentOfFoodToPop );
			happinessModifier.value = Mathf.Clamp (-percentOfFoodToPop, -5, 0);

		}
		//increase happiness and growth, and increase populous and growth
		else
		{
			//affect growth by 1/2 amount of surplus food
			populationModifier.value = (remainder / 2);

			//increase happiness and hapiness growth by percentage of surplus food compared to population.
			//happiness.AddAmount ( percentOfFoodToPop );
			happinessModifier.value = Mathf.Clamp (percentOfFoodToPop, 0, 5);
		}
	}
}
