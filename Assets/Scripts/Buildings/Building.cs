using UnityEngine;
using System.Collections.Generic;

public abstract class Building : MonoBehaviour
{
	#region PROPERTIES
	public bool IsClickable { get; private set; }

	public string DisplayName { get; private set; }
	#endregion


	#region PROTECTED VARIABLES
	protected Dictionary<string, float> mResourceModifiers;
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		mResourceModifiers = new Dictionary<string, float> ();
	}
	#endregion


	#region PUBLIC API
	public override string ToString ()
	{
		return string.Format ("{0}", DisplayName);
	}
	#endregion


	#region HELPER FUNCTIONS
	protected void Init (string displayName, bool isClickable = true)
	{
		IsClickable = isClickable;
		DisplayName = displayName;
	}
	#endregion
}
