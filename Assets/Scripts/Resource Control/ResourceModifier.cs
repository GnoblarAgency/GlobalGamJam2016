using UnityEngine;
using System.Collections;

public class ResourceModifier 
{
	public string Name { get; set; }
	public float Value { get; set; }

	public ResourceModifier (string resource, float value)
	{
		Name = resource;
		Value = value;
	}
}
