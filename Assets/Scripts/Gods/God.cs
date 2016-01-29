using UnityEngine;
using System.Collections.Generic;

public abstract class God
{
	#region PROPERTIES
	public string DisplayName { get; private set; }
	public string Title { get; private set; }
	public string Biography { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PROTECTED VARIABLES
	protected Dictionary<string, float> mResourceModifiers; 
	#endregion


	#region CONSTRUCTORS
	public God (string displayName, string title)
	{
		DisplayName = displayName;
		Title = title;

		mResourceModifiers = new Dictionary<string, float> ();
	}
	#endregion


	#region PUBLIC API
	#endregion


	#region HELPER FUNCTIONS
	#endregion
}

public class DiseaseGod : God
{
	#region CONSTRUCTORS
	public DiseaseGod ()
		: base ("Chalchiuhtotolin", "God of Disease and Plague")
	{
		mResourceModifiers.Add (ResourceNames.HAPPINESS, -5f);
		mResourceModifiers.Add (ResourceNames.FOOD, 5f);
	}
	#endregion
}

public class SacrificeGod : God
{
	#region CONSTRUCTORS
	public SacrificeGod ()
		: base ("Itzpapalotl", "Goddess of Sacrifice") {}
	#endregion


}

public class SunGod : God
{
	#region CONSTRUCTORS
	public SunGod ()
		: base ("Tonatiuh", "God of the Sun")
	{
		mResourceModifiers.Add (ResourceNames.HAPPINESS, 10f);
		mResourceModifiers.Add (ResourceNames.PRISONERS, -10f);
	}
	#endregion
}

public class WarGod : God
{
	#region CONSTRUCTORS
	public WarGod ()
		: base ("Mixcoatl", "God of War and the Hunt")
	{
		mResourceModifiers.Add (ResourceNames.POPULATION, -10f);
		mResourceModifiers.Add (ResourceNames.FOOD, 10f);
	}
	#endregion
}

public class FarmGod : God
{
	#region CONSTRUCTORS
	public FarmGod ()
		: base ("Chicomecoatl", "Goddess of Agriculture")
	{
		mResourceModifiers.Add (ResourceNames.PRISONERS, -10f);
		mResourceModifiers.Add (ResourceNames.FOOD, 10f);
	}
	#endregion
}