using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public enum ResourceType
{
	Food = 0,
	Happiness = 1,
	Population = 2,
	Prisoners = 3,
	Favour = 4
}

#region RESOURCES
/// A base class in order to represent our various resource types. Each contains a base growth value as well as an additional growth modifier.
public abstract class Resource 
{
	#region CONSTANTS
	/// The default growth per tick offered by this resource type
	public float BaseGrowth;
	/// The inital number of resources that we start
	public float BaseAmount;
	#endregion

	#region PROPERTIES
	public string DisplayName { get; private set; }

	/// The growth modifiers that are currently active for this resource.
	public List<ResourceGrowthModifier> GrowthModifiers { get; protected set; }
	/// The total amount of this resource that we have.
	public float TotalAmount { get; protected set; }
	#endregion

	public Resource (string name, float baseAmount, float baseGrowth)
	{
		DisplayName = name;
		BaseGrowth = baseGrowth;
		BaseAmount = TotalAmount = baseAmount;
		GrowthModifiers = new List<ResourceGrowthModifier> ();
	}


	public virtual void ApplyModifier (ResourceGrowthModifier modifier)
	{
		GrowthModifiers.Add (modifier);
	}

	public virtual void RemoveModifier (ResourceGrowthModifier modifier)
	{
		GrowthModifiers.Remove (modifier);
	}


	public virtual void AddAmount (float amount)
	{
		TotalAmount += amount;
	}
	public virtual void RemoveAmount (float amount)
	{
		TotalAmount -= amount;
		TotalAmount = TotalAmount < 0 ? 0 : TotalAmount;
	}


	/// Returns the current total growth value: base growth + modifiers
	public virtual float GetTotalGrowth ()
	{
		return BaseGrowth + GetAdditionalGrowth();	
	}

	/// Returns the amount of growth offered by the currently applied multipliers, excluding base growth.
	public virtual float GetAdditionalGrowth ()
	{
		float modifierGrowth = 0f;
		for (int i = 0 ; i < GrowthModifiers.Count ; i++)
		{ modifierGrowth += GrowthModifiers[i].value; }

		return modifierGrowth;
	}
		
	/// Updates the current total resources by the amount of growth. A divisor can be passed in order to perform incremental updates (such as per second...)
	public virtual void UpdateResourceTotal (float divisor = 1)
	{
		AddAmount (GetTotalGrowth() / divisor);
		TotalAmount = TotalAmount < 0 ? 0 : TotalAmount;
	}
}
	
public class FoodResource : Resource
{
	public FoodResource (float baseAmount = 10, float baseGrowth = 10)
		: base ("Food", baseAmount, baseGrowth) {}
}
	
public class PopulationResource : Resource
{
	public PopulationResource (float baseAmount = 5, float baseGrowth = 0)
		: base ("Population", baseAmount, baseGrowth) {}

	public override void AddAmount (float amount)
	{
		//don't increase more than 10% of itself
		float tenthOfPopulation = TotalAmount/10f;
		amount = Mathf.Clamp (amount, 0, tenthOfPopulation);
		base.AddAmount (amount);
	}
}

public class PrisonersResource : Resource
{
	public PrisonersResource (float baseAmount = 0, float baseGrowth = 0)
		: base ("Prisoners", baseAmount, baseGrowth) {}
}

public class HappinessResource : Resource
{
	public HappinessResource (float baseAmount = 60, float baseGrowth = 0)
		: base ("Happiness", baseAmount, baseGrowth) {}

	public override void AddAmount (float amount)
	{
		//don't increase more than 5% of itself
		float twentiethOfHappiness = TotalAmount/20f;
		amount = Mathf.Clamp (amount, 0, twentiethOfHappiness);
		base.AddAmount (amount);
	}

	/// Returns the amount of growth offered by the currently applied multipliers, excluding base growth.
	public override float GetAdditionalGrowth ()
	{
		float modifierGrowth = 0f;
		for (int i = 0 ; i < GrowthModifiers.Count ; i++)
		{ modifierGrowth += GrowthModifiers[i].value; }

		modifierGrowth = modifierGrowth > 5 ? 5 : modifierGrowth;

		return modifierGrowth;
	}
		
	public override void UpdateResourceTotal (float divisor = 1)
	{
		AddAmount (GetTotalGrowth() / divisor);
		TotalAmount = Mathf.Clamp (TotalAmount, 0, 100);
	}
}

/// Represents the favour of a god
public class FavourResource : Resource
{

	#region PUBLIC EVENTS
	//TODO Subscribe to these events to unless the all-loving goodness of your chosen god, 
	//or their unrelenting wrath. (These will be major events, such as eclipses, plagues etc with
	//accompanying animations.

	public static event Action Wrath = delegate {};
	public static event Action Curse = delegate {};
	public static event Action Neutral = delegate {};
	public static event Action Blessing = delegate {};
	public static event Action Delight = delegate {};
	#endregion

	public FavourResource (float baseAmount = 5, float baseGrowth = -1)
		: base ("Favour", baseAmount, baseGrowth) {}
	
	public override void UpdateResourceTotal (float divisor = 1)
	{
		TotalAmount += GetTotalGrowth() / divisor;
	}

	/// Will trigger a blessing or a curse based on the current favour value.
	public void DivineJudgement ()
	{
		//do some godly events based on their favour!
		if (TotalAmount <= -20)
		{ Wrath(); }
		else if (TotalAmount <= -10)
		{ Curse(); }
		else if (TotalAmount <= 10)
		{ Neutral(); }
		else if (TotalAmount <= 20)
		{ Blessing(); }
		else 
		{ Delight(); }
	}
}

#endregion