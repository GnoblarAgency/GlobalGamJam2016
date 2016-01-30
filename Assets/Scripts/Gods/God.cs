using UnityEngine;
using System.Collections.Generic;

public class God : MonoBehaviour
{
	#region PUBLIC VARIABLES
	public string displayName;
	public string title;

	[TextArea (3, 10)]
	public string biography;

	public ResourceModifier[] resourceModifiers = new ResourceModifier[0]; 

	public Curse[] curses = new Curse[0];
	public Blessing[] blessings = new Blessing[0];
	#endregion


	#region UNITY EVENTS
	#endregion


	#region PUBLIC API
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}