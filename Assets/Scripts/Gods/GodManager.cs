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

	void Start ()
	{

	}

	void Update ()
	{

	}
	#endregion


	#region PUBLIC API
	/// Changes the god that the people actively worshipping. This applies new modifiers to resources, removing the last god's modifiers.
	public void ChangeActiveGod (God god)
	{
		foreach (ResourceModifier rm in god.GetResourceModifiers())
			ResourcesManager.instance.RemoveModifier (rm);

		mActiveGod = god;

		foreach (ResourceModifier rm in god.GetResourceModifiers())
			ResourcesManager.instance.ApplyModifier (rm);
	}

	public God GetActiveGod ()
	{
		return mActiveGod;
	}
	#endregion



	#region HELPER FUNCTIONS
	#endregion
}
