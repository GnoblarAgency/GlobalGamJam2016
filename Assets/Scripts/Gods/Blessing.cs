using UnityEngine;
using System.Collections;

public class Blessing : DivineEffect 
{
	#region CONSTRUCTORS
	public Blessing (string displayName)
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
