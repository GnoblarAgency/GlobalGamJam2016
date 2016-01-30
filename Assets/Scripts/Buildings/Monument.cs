using UnityEngine;
using System.Collections;

public class Monument : Building
{
	#region PROPERTIES
	public God DedicatedGod { get; set; }
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		Init ("Monument");
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
