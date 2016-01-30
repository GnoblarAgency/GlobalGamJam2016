using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
public static class ResourceDefaultGrowthValues
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
	/// The default growth per tick offered by this resource type
	public readonly float BaseGrowth;
	#endregion

	#region PROPERTIES
	public string DisplayName { get; private set; }

	/// The growth modifiers that are currently active for this resource.
	public List<ResourceModifier> GrowthModifiers { get; protected set; }
	/// The total amount of this resource that we have.
	public float TotalAmount { get; protected set; }
	#endregion

	public Resource (string name, float baseGrowth)
	{
		DisplayName = name;
		BaseGrowth = baseGrowth;
		GrowthModifiers = new List<ResourceModifier> ();
	}


	public void ApplyModifier (ResourceModifier modifier)
	{
		GrowthModifiers.Add (modifier);
	}

	public void RemoveModifier (ResourceModifier modifier)
	{
		GrowthModifiers.Remove (modifier);
	}

	/// Returns the current total growth value: base growth + modifiers
	public float GetTotalGrowth ()
	{
		float modifierGrowth = 0f;
		for (int i = 0 ; i < GrowthModifiers.Count ; i++)
		{ modifierGrowth += GrowthModifiers[i].Value; }

		return BaseGrowth + modifierGrowth;	
	}

	/// Returns the amount of growth offered by the currently applied multipliers, excluding base growth.
	public float GetAdditionalGrowth ()
	{
		float modifierGrowth = 0f;
		for (int i = 0 ; i < GrowthModifiers.Count ; i++)
		{ modifierGrowth += GrowthModifiers[i].Value; }

		return modifierGrowth;
	}


	/// Applies the current growth value to the total amount of this resource.
	public virtual void UpdateResourceTotal ()
	{
		for (int i = 0 ; i < GrowthModifiers.Count ; i++)
		{ TotalAmount += GrowthModifiers[i].Value; }

		TotalAmount = TotalAmount < 0 ? 0 : TotalAmount;
	}
}
	
public class FoodResource : Resource
{
	public FoodResource (float initialValue = ResourceDefaultGrowthValues.FOOD)
		: base (ResourceNames.FOOD, initialValue) {}
}
	
public class PopulationResource : Resource
{
	public PopulationResource (float initialValue = ResourceDefaultGrowthValues.POPULATION)
		: base (ResourceNames.POPULATION, initialValue) {}
}

public class PrisonersResource : Resource
{
	public PrisonersResource (float initialValue = ResourceDefaultGrowthValues.PRISONERS) 
		: base (ResourceNames.PRISONERS, initialValue) {}
}

public class HappinessResource : Resource
{
	public HappinessResource (float initialValue = ResourceDefaultGrowthValues.HAPPINESS)
		: base (ResourceNames.HAPPINESS, initialValue) {
	}

	/// Applies the current growth value to the total amount of this resource.
	public override void UpdateResourceTotal ()
	{
		TotalAmount += GetTotalGrowth();
		TotalAmount = Mathf.Clamp (TotalAmount, 0, 100);
	}
}

#endregion