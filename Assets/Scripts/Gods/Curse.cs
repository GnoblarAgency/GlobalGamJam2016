using UnityEngine;
using System.Collections;

public class Curse : DivineEffect 
{
	#region CONSTRUCTORS
	public Curse (string displayName)
		: base (displayName)
	{

	}
	#endregion


	#region PUBLIC API
	public override void ApplyEffect ()
	{
		throw new System.NotImplementedException ();
	}
	#endregion
}
