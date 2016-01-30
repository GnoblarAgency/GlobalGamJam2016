using UnityEngine;
using System.Collections.Generic;

public sealed  class GodManager : MonoBehaviour
{
	#region PROPERTIES
	public static GodManager Instance { get; private set; }

	/// The currently selected God to which the people are praying
	public God ActiveGod { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PRIVATE VARIABLES
	private God[] mAvailableGods;
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;

			mAvailableGods = Resources.LoadAll<God> ("Gods/"); 

			SelectActiveGod(2);
		}
		else
		{
			Debug.LogError ("There is more than one GodManager in the scene!");
		}
	}

	void Update ()
	{

	}
	#endregion


	#region PUBLIC API
	/// Changes the god that the people actively worshipping. This applies new modifiers to resources, removing the last god's modifiers.
	public void SelectActiveGod (int i)
	{
		if (ActiveGod)
		{ ActiveGod.RemoveEffect(); }

		ActiveGod = mAvailableGods[i];
		ActiveGod.ApplyEffect();
	}
	#endregion



	#region HELPER FUNCTIONS
	#endregion
}
