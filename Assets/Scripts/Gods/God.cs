using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class God : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public string displayName;
	public string title;

	[TextArea (3, 10)]
	public string biography;

	public Sprite image;

	public ResourceGrowthModifier[] resourceModifiers = new ResourceGrowthModifier[0]; 

	public Curse[] curses = new Curse[0];
	public Blessing[] blessings = new Blessing[0];

	public FavourResource favour = new FavourResource (9);
	#endregion


	#region UNITY EVENTS
	void Start ()
	{
		ResourcesManager.OnTick += CheckBlessingCurse;
	}
	void Update ()
	{
		
	}
	#endregion


	#region PUBLIC API
	public void ApplyEffect ()
	{
		for (int i = 0; i < resourceModifiers.Length; ++i)
		{ ResourcesManager.instance.ApplyModifier (resourceModifiers[i]); }
	}

	public void RemoveEffect ()
	{
		for (int i = 0; i < resourceModifiers.Length; ++i)
		{ ResourcesManager.instance.RemoveModifier (resourceModifiers[i]); }
	}

	/// Adds a new growth modifier that increases the gods favour. This should be used for your initally chosen god.
	public void AddFavourModifier (float growth)
	{
		ResourceGrowthModifier favourMod = new ResourceGrowthModifier ( ResourceType.Favour, growth );

		List <ResourceGrowthModifier> expandedList = new List<ResourceGrowthModifier> (resourceModifiers);
		expandedList.Add (favourMod);
		resourceModifiers = expandedList.ToArray ();
	}
	#endregion


	#region HELPER FUNCTIONS
	void CheckBlessingCurse ()
	{
		//do some godly events based on their favour!
		if (favour.TotalAmount <= -10)
		{ 
			int idx = UnityEngine.Random.Range (0, blessings.Length);
			EventsManager.Instance.InstantiateBlessing (blessings [idx]); 
		}
		else if (favour.TotalAmount >= 10)
		{ 
			int idx = UnityEngine.Random.Range (0, curses.Length);
			EventsManager.Instance.InstantiateCurse (curses[idx]); 
		}
	}
	#endregion
}