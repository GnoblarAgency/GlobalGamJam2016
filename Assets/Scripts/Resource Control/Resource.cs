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
	/// The growth per tick offered by this resource type
	public readonly float BaseGrowth;
	#endregion

	#region PROPERTIES
	public string DisplayName { get; private set; }

	/// The growth per tick after applying modifiers.
	public float ModifiedGrowth { get; protected set; }
	/// The total amount of this resource that we have.
	public float TotalAmount { get; protected set; }
	#endregion

	public Resource (string name, float baseGrowth)
	{
		DisplayName = name;
		BaseGrowth = ModifiedGrowth = baseGrowth;
	}

	public void ApplyModifier (float value)
	{
		ModifiedGrowth += value;
	}

	public void RemoveModifier (float value)
	{
		ModifiedGrowth -= value;
	}

	/// Applies the current growth value to the total amount of this resource.
	public virtual void UpdateResourceTotal ()
	{
		TotalAmount += ModifiedGrowth;
		TotalAmount = TotalAmount < 0 ? 0 : TotalAmount;
	}
}
	
public class FoodResource : Resource
{
	public FoodResource (float initialValue = ResourceDefaultValues.FOOD)
		: base (ResourceNames.FOOD, initialValue) {}
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

public class HappinessResource : Resource
{
	public HappinessResource (float initialValue = ResourceDefaultValues.HAPPINESS)
		: base (ResourceNames.HAPPINESS, initialValue) {
	}

	/// Applies the current growth value to the total amount of this resource.
	public override void UpdateResourceTotal ()
	{
		TotalAmount += ModifiedGrowth;
		TotalAmount = Mathf.Clamp (TotalAmount, 0, 100);
	}
}

#endregion