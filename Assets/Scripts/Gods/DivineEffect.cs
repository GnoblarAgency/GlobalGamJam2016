using UnityEngine;
using System.Collections;

public abstract class DivineEffect : MonoBehaviour
{
	#region PROPERTIES
	public string DisplayName { get; private set; }
	#endregion


	#region CONSTRUCTORS
	public DivineEffect (string displayName)
	{
		DisplayName = displayName;
	}
	#endregion


	#region PUBLIC API
	public abstract void ApplyEffect ();
	public abstract void RemoveEffect ();
	#endregion
}
