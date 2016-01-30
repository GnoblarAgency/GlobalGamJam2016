using UnityEngine;
using System.Collections;

public class ResourceModifier 
{
	#region PUBLIC VARIABLES
	public string Name;
	public float Value;
	#endregion

	public ResourceModifier (string resource, float value)
	{
		Name = resource;
		Value = value;
	}
}
