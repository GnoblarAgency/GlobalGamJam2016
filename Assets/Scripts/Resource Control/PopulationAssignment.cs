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
		foodCollecting = new ResourceModifier(ResourceNames.FOOD, DetermineFoodModifier());
		prisonerCollecting = new ResourceModifier(ResourceNames.PRISONERS, DetermineFoodModifier());

		ApplyModifiers();
	}
	#endregion


	public void UpdatePopulationAssignment()
	{
		foodCollecting.Value = DetermineFoodModifier();
		prisonerCollecting.Value = DeterminePrisonerModifier();


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
