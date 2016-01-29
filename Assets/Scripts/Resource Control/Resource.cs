﻿using UnityEngine;
using System.Collections;


#region RESOURCES KEYS
public static class ResourceNames 
{
	public const string FOOD = "Food";
	public const string HAPPINESS = "Happiness";
	public const string POPULATION = "Population";
	public const string PRISONERS = "Prisoners";
}
#endregion


#region INITIALIZATION VALUES
public static class ResourceDefaultValues
{
	public const float FOOD = 10;
	public const float HAPPINESS = 10;
	public const float POPULATION = 10;
	public const float PRISONERS = 10;
}
#endregion


#region RESOURCES
/// A base class in order to represent our various resource types
public abstract class Resource 
{
	#region PROPERTIES
	public string Name { get; private set; }
	public float Value { get; protected set; }
	#endregion

	public Resource (string name)
	{
		Name = name ;
	}

	public void SetValue (float value)
	{
		Value = value;
	}

}
	
public class FoodResource : Resource
{
	public FoodResource (float initialValue = ResourceDefaultValues.FOOD)
		: base (ResourceNames.FOOD)
	{
		Value = initialValue;
	}
}

public class HappinessResource : Resource
{
	public HappinessResource (float initialValue = ResourceDefaultValues.HAPPINESS)
		: base (ResourceNames.HAPPINESS)
	{
		Value = initialValue;
	}
}

public class PopulationResource : Resource
{
	public PopulationResource (float initialValue = ResourceDefaultValues.POPULATION)
		: base (ResourceNames.POPULATION)
	{
		Value = initialValue;
	}
}

public class PrisonersResource : Resource
{
	public PrisonersResource (float initialValue = ResourceDefaultValues.PRISONERS) 
		: base (ResourceNames.PRISONERS)
	{
		Value = initialValue;
	}
}
#endregion