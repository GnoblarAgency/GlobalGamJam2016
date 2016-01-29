using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public sealed class UIManager : MonoBehaviour
{

	#region PROPERTIES
	public static UIManager instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	Text debugOutResources;
	#endregion


	#region PRIVATE VARIABLES
	#endregion


	#region UNITY EVENTS
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("There is more than one UIManager in the scene!");
		}
	}

	void Start () 
	{

	}

	void Update () 
	{

	}
	#endregion


	#region PUBLIC_FACING API
	#endregion


	#region INITIALIZATION
	void Init ()
	{

	}
	#endregion

	#region DEBUG
	void DebugOutResources ()
	{
		if (debugOutResources != null)
		{
			debugOutResources.text = 
				"RESOURCES:" + "\n" +
				"Food: " + 
				"Happiness: " +
				"Population" +
				"Prisoners";
		}
	}
	#endregion
}
