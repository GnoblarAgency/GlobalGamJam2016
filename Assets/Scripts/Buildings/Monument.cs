using UnityEngine;
using System.Collections;

public class Monument : Building
{
	#region PROPERTIES
	public God DedicatedGod { get; set; }
	public string GodDecidicateTo;
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Monument");
		CostToBuild = 700;
	}

	void OnEnable ()
	{
//		ResourceGrowthModifier modifier = new ResourceGrowthModifier ( ResourceType.Favour , 2f);
//		ResourcesManager.instance.ApplyModifier (modifier);
//		mResourceModifiers.Add (modifier);
	}
	#endregion


	#region PUBLIC API
	public override string ToString ()
	{
		if (DedicatedGod == null)
		{ return base.ToString (); }

		return string.Format ("{0} to {1}", DisplayName, DedicatedGod.displayName);
	}
	#endregion
}
