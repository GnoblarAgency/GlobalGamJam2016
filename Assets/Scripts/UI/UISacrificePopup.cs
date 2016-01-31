﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISacrificePopup : MonoBehaviour
{
	#region CONSTANTS
	private string SACRIFICE_FORMAT = "Sacrifice to {0}";
	#endregion


	#region PUBLIC VARIABLES
	public Transform godListParent;
	public UIGodListItem godItemPrefab;

	public Text header;
	public Image godImage;

	public Slider prisoners;
	public Slider population;

	public Text prisonerField;
	public Text populationField;
	#endregion


	#region PRIVATE VARIABLES
	private God mSelectedGod;

	private ResourcesManager manager;
	#endregion


	#region UNITY EVENTS
	void Start ()
	{
		ToggleGroup toggleParent = godListParent.GetComponent<ToggleGroup>();

		foreach (God god in GodManager.Instance.AvailableGods)
		{
			UIGodListItem godItem = Instantiate(godItemPrefab);

			godItem.SetDetails (god.icon, god.favour.GetNormalisedValue());

			godItem.transform.SetParent(godListParent, false);

			God selectedGod = god;
			godItem.GetComponent<Toggle>().group = toggleParent;
			godItem.GetComponent<Toggle>().onValueChanged.AddListener( (selected) => {
				if (selected)
				{ SetSelectedGod(selectedGod); }
			});

			if (god == GodManager.Instance.ActiveGod)
			{ godItem.GetComponent<Toggle>().isOn = true; }
		}
	}

	void OnEnable()
	{
		prisonerField.text = "0";
		populationField.text = "0";
	}
		
	void Update()
	{
		if (manager == null)
		{
			manager = ResourcesManager.instance;
		}

		prisoners.maxValue = manager.GetResourcePrisoners().TotalAmount;
		population.maxValue = manager.GetResourcePopulation().TotalAmount;
	}
	#endregion


	#region PUBLIC API
	public void Sacrifice () 
	{
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
	#endregion


	#region HELPER FUNCTIONS
	void SetSelectedGod(God god)
	{
		mSelectedGod = god;

		header.text = string.Format(SACRIFICE_FORMAT, mSelectedGod.displayName);
		godImage.sprite = god.image;
	}
	#endregion
}