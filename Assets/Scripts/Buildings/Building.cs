using UnityEngine;
using System.Collections.Generic;

public abstract class Building : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public bool isClickable = true;

	public string displayName;
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
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}
