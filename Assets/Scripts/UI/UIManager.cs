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

	void Start () 
	{

	}

	void Update () 
	{
		DebugOutResources();
	}
	#endregion


	#region PUBLIC_FACING API
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
				" + " +  (ResourcesManager.instance.GetResourceFood ().ModifiedGrowth - ResourcesManager.instance.GetResourceFood ().BaseGrowth ) + "] \n" +

				"Happiness: " + ResourcesManager.instance.GetResourceHappiness ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourceHappiness ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourceHappiness ().ModifiedGrowth - ResourcesManager.instance.GetResourceHappiness ().BaseGrowth ) + "] \n" +

				"Population: " + ResourcesManager.instance.GetResourcePopulation ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourcePopulation ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourcePopulation ().ModifiedGrowth - ResourcesManager.instance.GetResourcePopulation ().BaseGrowth ) + "] \n" +

				"Prisoners: " + ResourcesManager.instance.GetResourcePrisoners ().TotalAmount +
				" [ " + ResourcesManager.instance.GetResourcePrisoners ().BaseGrowth + 
				" + " +  (ResourcesManager.instance.GetResourcePrisoners ().ModifiedGrowth - ResourcesManager.instance.GetResourcePrisoners ().BaseGrowth ) + "] \n";
		}
	}
	#endregion
}
