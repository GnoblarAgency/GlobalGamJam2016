using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
	#region CONSTANTS
	public const string NUMBER_FORMAT 	= "{0:0} ({1:0})";
	#endregion


	#region PUBLIC VARIABLES
	public Text population;
	public Text food;
	public Text prisoners;

	public Sprite[] happinessIcons = new Sprite[3];

	public Scrollbar happiness;
	public Image scrollIcon;
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
		population.text = string.Format (NUMBER_FORMAT, mPopulation.TotalAmount, mPopulation.GetAdditionalGrowth());
		food.text = string.Format (NUMBER_FORMAT, mFood.TotalAmount, mFood.GetAdditionalGrowth());
		prisoners.text = string.Format (NUMBER_FORMAT, mPrisoners.TotalAmount, mPrisoners.GetAdditionalGrowth());

		happiness.value = mHappiness.TotalAmount / 100;

		if (mHappiness.TotalAmount < 40)
		{
			scrollIcon.sprite = happinessIcons[0];
		}
		else if (mHappiness.TotalAmount < 60)
		{
			scrollIcon.sprite = happinessIcons[1];
		}
		else if (mHappiness.TotalAmount < 100)
		{
			scrollIcon.sprite = happinessIcons[2];
		}
	}
	#endregion
}
