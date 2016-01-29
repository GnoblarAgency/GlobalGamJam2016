using UnityEngine;
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
	#region CONSTANTS
	public readonly float BaseGrowth;
	#endregion

	#region PROPERTIES
	public string DisplayName { get; private set; }

	public float ModifiedGrowth { get; protected set; }
	public float TotalAmount { get; protected set; }
	#endregion

	public Resource (string name, float baseGrowth)
	{
		DisplayName = name;
		BaseGrowth = baseGrowth;
	}

	public void ApplyModifier (float value)
	{
		ModifiedGrowth += value;
	}

	public void RemoveModifier (float value)
	{
		ModifiedGrowth -= value;
	}
}
	
public class FoodResource : Resource
{
	public FoodResource (float initialValue = ResourceDefaultValues.FOOD)
		: base (ResourceNames.FOOD, initialValue) {}
}

public class HappinessResource : Resource
{
	public HappinessResource (float initialValue = ResourceDefaultValues.HAPPINESS)
		: base (ResourceNames.HAPPINESS, initialValue) {}
}

public class PopulationResource : Resource
{
	public PopulationResource (float initialValue = ResourceDefaultValues.POPULATION)
		: base (ResourceNames.POPULATION, initialValue) {}
}

public class PrisonersResource : Resource
{
	public PrisonersResource (float initialValue = ResourceDefaultValues.PRISONERS) 
		: base (ResourceNames.PRISONERS, initialValue) {}
}
#endregion