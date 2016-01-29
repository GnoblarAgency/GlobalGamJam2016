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
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}
