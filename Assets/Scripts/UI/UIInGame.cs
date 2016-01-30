using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
	#region CONSTANTS
	public const string POPULATION_FORMAT 	= "POPULATION - {0} ({1})";
	public const string HAPPINESS_FORMAT 	= "HAPPINESS - {0} ({1})";
	public const string FOOD_FORMAT 		= "FOOD - {0} ({1})";
	public const string PRISONERS_FORMAT 	= "PRISONERS - {0} ({1})";
	#endregion


	#region PUBLIC VARIABLES
	public Text population;
	public Text happiness;
	public Text food;
	public Text prisoners;
	#endregion


	#region PRIVATE VARIABLES
	private Resource mPopulation;
	private Resource mHappiness;
	private Resource mFood;
	private Resource mPrisoners;
	#endregion


	#region CONSTRUCTORS
	void Start ()
	{
		mPopulation = ResourcesManager.instance.GetResourcePopulation ();
		mHappiness = ResourcesManager.instance.GetResourceHappiness ();
		mFood = ResourcesManager.instance.GetResourceFood ();
		mPrisoners = ResourcesManager.instance.GetResourcePrisoners ();
	}

	void Update ()
	{
		population.text = string.Format (POPULATION_FORMAT, mPopulation.TotalAmount, mPopulation.GetTotalGrowth ());
		happiness.text = string.Format (HAPPINESS_FORMAT, mHappiness.TotalAmount, mHappiness.GetTotalGrowth ());
		food.text = string.Format (FOOD_FORMAT, mFood.TotalAmount, mFood.GetTotalGrowth ());
		prisoners.text = string.Format (PRISONERS_FORMAT, mPrisoners.TotalAmount, mPrisoners.GetTotalGrowth ());
	}
	#endregion
}
