using UnityEngine;
using System.Collections;

public class GodSelectionString : MonoBehaviour {

	public string god;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GodChal ()
	{
		god = "Chalchiuhtotolin"; 
	}
	public void GodChico ()
	{
		god = "Chicomecoatl"; 
	}
	public void GodItz ()
	{
		god = "Itzpapalotl"; 
	}
	public void GodMix ()
	{
		god = "Mixcoatl"; 
	}
	public void GodTon ()
	{
		god = "Tonatiuh"; 
	}
}
