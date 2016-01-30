using UnityEngine;
using System.Collections;

[System.Serializable]
public class ResourceModifier 
{
	#region PUBLIC VARIABLES
	public ResourceType resourceType;
	public float value;
	#endregion

	public ResourceModifier (ResourceType type, float modifier)
	{
		resourceType = type;
		value = modifier;
	}
}
