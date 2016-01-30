using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemplePopup : MonoBehaviour {

	public Slider prisoners;
	public Slider population;

	public InputField prisonerField;
	public InputField populationField;

	private ResourcesManager manager;

	void Update()
	{
		if (manager == null)
		{
			 manager = ResourcesManager.instance;
		}

		prisoners.maxValue = manager.GetResourcePrisoners().TotalAmount;
		population.maxValue = manager.GetResourcePopulation().TotalAmount;
	}

	void OnEnable()
	{
		ResourcesManager manager = ResourcesManager.instance;
		prisonerField.text = "0";
		populationField.text = "0";
	}

	public void Sacrifice () 
	{
		ResourcesManager manager = ResourcesManager.instance;

		SacrificePopulation ();
		SacrificePrisoner ();

	}

	public void SacrificePopulation ()
	{
		manager.GetResourcePopulation().RemoveAmount(int.Parse(populationField.text));

		int sacrifices = int.Parse(populationField.text);

		//decrease percentage of happiness proportional to percentage of population killed, up to 25%
		int happinessDeficit = (int) (((float)sacrifices / manager.GetResourcePopulation().TotalAmount) * 100);
		happinessDeficit = Mathf.Clamp (happinessDeficit, 0, 25);
		manager.GetResourceHappiness().RemoveAmount (happinessDeficit);

		//TODO Decrease happiness severely, but increase fortune alot (x2.5).
	}

	public void SacrificePrisoner ()
	{
		manager.GetResourcePrisoners().RemoveAmount(int.Parse(prisonerField.text));

		//TODO Dont affect happiness, but increase fortune (x1)
	}


	public void SetPrisonerField()
	{
		prisonerField.text =  prisoners.value.ToString();
	}
	
	public void SetPopulationField()
	{
		populationField.text = population.value.ToString();
	}

	public void SetPrisonerSlider()
	{
		prisoners.value =   int.Parse(prisonerField.text);
	}

	public void SetPopulationSlider()
	{
		population.value =   int.Parse(populationField.text);
	}
}
