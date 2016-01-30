using UnityEngine;
using System.Collections.Generic;

public sealed  class GodManager : MonoBehaviour
{
	#region PROPERTIES
	public static GodManager Instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PRIVATE VARIABLES
	/// The currently selected God to which the people are praying
	private God mActiveGod;
	/// Effects applied by the active god
	private List <ResourceModifier> mActiveGodModifiers = new List<ResourceModifier> ();
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError ("There is more than one GodManager in the scene!");
		}
	}
	#endregion


	#region PUBLIC API
	/// Changes the god that the people actively worshipping. This applies new modifiers to resources, removing the last god's modifiers.
	public void ChangeActiveGod (God god)
	{
		foreach (ResourceModifier rm in mActiveGodModifiers)
			ResourcesManager.instance.RemoveModifier (rm);
		mActiveGodModifiers.Clear ();

		mActiveGod = god;

		foreach (ResourceModifier rm in mActiveGod.GetResourceModifiers())
		{
			ResourcesManager.instance.ApplyModifier (rm);
			mActiveGodModifiers.Add (rm);
		}
	}
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}
