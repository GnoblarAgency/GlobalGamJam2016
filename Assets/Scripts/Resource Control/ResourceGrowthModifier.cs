using UnityEngine;
using System.Collections;

[System.Serializable]
public class ResourceGrowthModifier 
{
	#region PUBLIC VARIABLES
	public ResourceType resourceType;
	public float value;
	#endregion

	public ResourceGrowthModifier (ResourceType type, float modifier)
	{
		resourceType = type;
		value = modifier;
	}
}
