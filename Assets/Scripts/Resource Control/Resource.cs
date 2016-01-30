using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public enum ResourceType
{
	Food,
	Happiness,
	Population,
	Prisoners
}

#region RESOURCES KEYS
public static class ResourceNames 
{
	public const string FOOD = "Food";
	public const string HAPPINESS = "Happiness";
	public const string POPULATION = "Population";
	public const string PRISONERS = "Prisoners";
	public const string FAVOUR = "Favour";
}
#endregion


#region RESOURCES
/// A base class in order to represent our various resource types
public abstract class Resource 
{
	#region CONSTANTS
	/// The default growth per tick offered by this resource type
	public readonly float BaseGrowth;
	/// The inital number of resources that we start
	public readonly float BaseAmount;
	#endregion

	#region PROPERTIES
	public string DisplayName { get; private set; }

	/// The growth modifiers that are currently active for this resource.
	public List<ResourceModifier> GrowthModifiers { get; protected set; }
	/// The total amount of this resource that we have.
	public float TotalAmount { get; protected set; }
	#endregion

	public Resource (string name, float baseAmount, float baseGrowth)
	{
		DisplayName = name;
		BaseGrowth = baseGrowth;
		BaseAmount = baseAmount;
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


	public void AddAmount (float amount)
	{
		TotalAmount += amount;
	}
	public void RemoveAmount (float amount)
	{
		TotalAmount -= amount;
	}

	/// Returns the current total growth value: base growth + modifiers
	public float GetTotalGrowth ()
	{
		return BaseGrowth + GetAdditionalGrowth();	
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
		TotalAmount += GetTotalGrowth();
		TotalAmount = TotalAmount < 0 ? 0 : TotalAmount;
	}
}
	
public class FoodResource : Resource
{
	public FoodResource (float baseAmount = 10, float baseGrowth = 10)
		: base (ResourceNames.FOOD, baseAmount, baseGrowth) {}
}
	
public class PopulationResource : Resource
{
	public PopulationResource (float baseAmount = 5, float baseGrowth = 0)
		: base (ResourceNames.POPULATION, baseAmount, baseGrowth) {}
}

public class PrisonersResource : Resource
{
	public PrisonersResource (float baseAmount = 0, float baseGrowth = 0)
		: base (ResourceNames.PRISONERS, baseAmount, baseGrowth) {}
}

public class HappinessResource : Resource
{
	public HappinessResource (float baseAmount = 60, float baseGrowth = 0)
		: base (ResourceNames.HAPPINESS, baseAmount, baseGrowth) {}

	/// Applies the current growth value to the total amount of this resource.
	public override void UpdateResourceTotal ()
	{
		TotalAmount += GetTotalGrowth();
		TotalAmount = Mathf.Clamp (TotalAmount, 0, 100);
	}
}

public class FavourResource : Resource
{

	#region PUBLIC EVENTS
	//TODO Subscribe to these events to unless the all-loving goodness of your chosen god, 
	//or their unrelenting wrath. (These will be major events, such as eclipses, plagues etc with
	//accompanying animations.

	public static event Action Curse = delegate {};
	public static event Action Neutral = delegate {};
	public static event Action Blessing = delegate {};
	#endregion

	public FavourResource (float baseAmount = 5, float baseGrowth = 0)
		: base (ResourceNames.FAVOUR, baseAmount, baseGrowth) {}

	/// Applies the current growth value to the total amount of this resource.
	public override void UpdateResourceTotal ()
	{
		TotalAmount += GetTotalGrowth();
	}
}

#endregion