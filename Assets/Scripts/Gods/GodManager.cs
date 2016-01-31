using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed  class GodManager : MonoBehaviour
{
	#region PROPERTIES
	public static GodManager Instance { get; private set; }

	/// The currently selected God to which the people are praying
	public God ActiveGod { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	public Text debugOutput;
	#endregion


	#region PRIVATE VARIABLES
	private List<God> mGods;
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;

			mGods = new List<God>();
			God[] availableGods = Resources.LoadAll<God> ("Gods/");

			for (int i = 0; i < availableGods.Length; ++i)
			{ 
				God god = Instantiate (availableGods[i]); 
				god.transform.SetParent (transform);

				mGods.Add(god);
			}

			SelectActiveGod(2);
		}
		else
		{
			Debug.LogError ("There is more than one GodManager in the scene!");
		}
	}

	void Update ()
	{
		DebugOutput ();
	}
	#endregion


	#region PUBLIC API
	/// Changes the god that the people actively worshipping. This applies new modifiers to resources, removing the last god's modifiers.
	public void SelectActiveGod (int i)
	{
		if (ActiveGod)
		{ ActiveGod.RemoveEffect(); }

		ActiveGod = mGods[i];
		ActiveGod.ApplyEffect();

		ActiveGod.AddFavourModifier (1.5f);
	}

	public void UpdateGodFavours (float divisor = 1)
	{
		foreach (God g in mGods)
		{
			g.favour.UpdateResourceTotal (divisor);
		}
	}

	public void CheckDivineJudgement ()
	{
		foreach (God g in mGods)
		{
			g.favour.DivineJudgement ();
		}
	}
	#endregion


	#region HELPER FUNCTIONS
	void DebugOutput ()
	{
		if (debugOutput != null)
		{
			debugOutput.text = "GODS:\n";
			foreach (God god in mGods)
			{
				debugOutput.text += god.displayName + ": " + god.favour.TotalAmount + " + " + god.favour.GetTotalGrowth() + "\n";
			}
		}
	}
	#endregion
}
