using UnityEngine;
using System.Collections;

public abstract class God
{
	#region PROPERTIES
	public string DisplayName { get; private set; }
	public string Title { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PRIVATE VARIABLES
	#endregion


	#region CONSTRUCTORS
	public God (string displayName, string title)
	{
		DisplayName = displayName;
		Title = title;
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

	}
	#endregion
}

public class SacrificeGod : God
{
	#region CONSTRUCTORS
	public SacrificeGod ()
		: base ("Itzpapalotl", "Goddess of Sacrifice")
	{

	}
	#endregion
}

public class SunGod : God
{
	#region CONSTRUCTORS
	public SunGod ()
		: base ("Tonatiuh", "God of the Sun")
	{

	}
	#endregion
}

public class WarGod : God
{
	#region CONSTRUCTORS
	public WarGod ()
		: base ("Mixcoatl", "God of War and the Hunt")
	{

	}
	#endregion
}

public class FarmGod : God
{
	#region CONSTRUCTORS
	public FarmGod ()
		: base ("Chicomecoatl", "Goddess of Agriculture")
	{

	}
	#endregion
}