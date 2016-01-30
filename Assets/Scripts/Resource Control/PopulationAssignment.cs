using UnityEngine;
using System.Collections;

public class PopulationAssignment : MonoBehaviour {


	#region PROPERTIES
	public static PopulationAssignment instance { get; private set; }
	#endregion

	private ResourceGrowthModifier foodCollecting;
	private ResourceGrowthModifier prisonerCollecting;

	public float foodAssignment = 0.5f;
	public float prisonerAssignment = 0.5f;

	public float foodClamp = 0.5f;
	public float prisonerClamp = 0.25f;


	#region UNITY EVENTS
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("There is more than one PopulationAssignment in the scene!");
		}
	}
		
	void Start () 
	{
		foodCollecting = new ResourceGrowthModifier (ResourceType.Food, DetermineFoodModifier());
		prisonerCollecting = new ResourceGrowthModifier (ResourceType.Prisoners, DeterminePrisonerModifier());

		//set our modifiers so that we can update them directly
		ApplyModifiers();
	}
	#endregion


	public void UpdatePopulationAssignment()
	{
		foodCollecting.value = DetermineFoodModifier();
		prisonerCollecting.value = DeterminePrisonerModifier();
	}

	public float DetermineFoodModifier()
	{
		return (ResourcesManager.instance.GetResourcePopulation().TotalAmount*foodAssignment)*foodClamp;
	}


	public float DeterminePrisonerModifier()
	{
		return (ResourcesManager.instance.GetResourcePopulation().TotalAmount*prisonerAssignment)*prisonerClamp;
	}

	private void ApplyModifiers()
	{
		ResourcesManager.instance.ApplyModifier (foodCollecting);
		ResourcesManager.instance.ApplyModifier (prisonerCollecting);
	}
}
