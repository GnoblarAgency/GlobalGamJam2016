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

		manager.GetResourcePopulation().RemoveAmount(int.Parse(populationField.text));
		manager.GetResourcePrisoners().RemoveAmount(int.Parse(prisonerField.text));
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
