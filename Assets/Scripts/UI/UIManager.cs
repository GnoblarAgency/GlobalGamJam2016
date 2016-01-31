using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public sealed class UIManager : MonoBehaviour
{

	#region PROPERTIES
	public static UIManager instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	public Text debugOutResources;

	public GameObject templeUI;
	public GameObject barracksUI;
	public GameObject farmUI;
	public UIEventBox eventBox; 
	#endregion


	#region PRIVATE VARIABLES
	#endregion


	#region UNITY EVENTS
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("There is more than one UIManager in the scene!");
		}
	}
		
	void Update () 
	{
		DebugOutResources();
	}
	#endregion


	#region PUBLIC_FACING API
	public void ShowTempleScreen ()
	{
		HideAll ();

		templeUI.SetActive (true);
	}

	public void ShowBarracksScreen ()
	{
		HideAll ();

		barracksUI.SetActive (true);
	}

	public void ShowFarmScreen ()
	{
		HideAll ();

		farmUI.SetActive (true);
	}

	public void ShowEventScreen (Event activeEvent)
	{
		HideAll ();

		eventBox.gameObject.SetActive (true);
		eventBox.SetDetails (null, activeEvent.displayName, activeEvent.description);
	}

	public bool IsScreenVisible ()
	{
		return templeUI.activeSelf || barracksUI.activeSelf || farmUI.activeSelf;
	}
	#endregion


	#region HELPER FUNCTIONS
	void HideAll ()
	{
		if (templeUI)
		{ templeUI.SetActive (false); }

		if (barracksUI)
		{ barracksUI.SetActive (false); }
			
		if (farmUI)
		{ farmUI.SetActive (false); }

		if (eventBox)
		{ eventBox.gameObject.SetActive (false); }
	}

	#endregion


	#region INITIALIZATION
	void Init ()
	{

	}
	#endregion


	#region DEBUG
	void DebugOutResources ()
	{
		if (debugOutResources != null)
		{
			debugOutResources.text = 
				"RESOURCES:" + "\n" +

				"Food: " + ResourcesManager.instance.GetResourceFood ().TotalAmount + 
				" [ " + ResourcesManager.instance.GetResourceFood ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourceFood ().GetTotalGrowth() - ResourcesManager.instance.GetResourceFood ().BaseGrowth ) + "] \n" +

				"Happiness: " + ResourcesManager.instance.GetResourceHappiness ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourceHappiness ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourceHappiness ().GetTotalGrowth() - ResourcesManager.instance.GetResourceHappiness ().BaseGrowth ) + "] \n" +

				"Population: " + ResourcesManager.instance.GetResourcePopulation ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourcePopulation ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourcePopulation ().GetTotalGrowth() - ResourcesManager.instance.GetResourcePopulation ().BaseGrowth ) + "] \n" +

				"Prisoners: " + ResourcesManager.instance.GetResourcePrisoners ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourcePrisoners ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourcePrisoners ().GetTotalGrowth() - ResourcesManager.instance.GetResourcePrisoners ().BaseGrowth ) + "] \n";

			string info = "";
			info += "\nFOOD: " +"\n";
			foreach (ResourceGrowthModifier rm in ResourcesManager.instance.GetResourceFood ().GrowthModifiers )
			{
				info += rm.value + "\n";
			}

			info += "\nHAPPINESS: " +"\n";
			foreach (ResourceGrowthModifier rm in ResourcesManager.instance.GetResourceHappiness ().GrowthModifiers )
			{
				info += rm.value + "\n";
			}

			info += "\nPOPULATION: " +"\n";
			foreach (ResourceGrowthModifier rm in ResourcesManager.instance.GetResourcePopulation ().GrowthModifiers )
			{
				info += rm.value + "\n";
			}

			info += "\nPRISONERS: " + "\n";
			foreach (ResourceGrowthModifier rm in ResourcesManager.instance.GetResourcePrisoners ().GrowthModifiers )
			{
				info += rm.value + "\n";
			}

			debugOutResources.text += info;
		}
	}
	#endregion
}
