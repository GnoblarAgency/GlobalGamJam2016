using UnityEngine;
using System.Collections;

public class PopulationAssignment : MonoBehaviour {


	#region PROPERTIES
	public static PopulationAssignment instance { get; private set; }
	#endregion

	private ResourceModifier foodCollecting;
	private ResourceModifier prisonerCollecting;

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
		foodCollecting = new ResourceModifier(ResourceType.Food, DetermineFoodModifier());
		prisonerCollecting = new ResourceModifier(ResourceType.Prisoners, DetermineFoodModifier());

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

	public void ApplyModifiers()
	{
		ResourcesManager.instance.ApplyModifier(foodCollecting);
		ResourcesManager.instance.ApplyModifier(prisonerCollecting);

	}
}
