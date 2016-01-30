using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour
{
	#region PROPERTIES
	public static BuildingManager Instance { get; private set; }
	#endregion


	#region PUBLIC VARIABLES
	#endregion


	#region PRIVATE VARIABLES
	#endregion


	#region UNITY EVENTS
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError ("There is more than one BuildingManager in the scene!");
		}
	}

	void Update () 
	{
		if (Input.GetMouseButtonUp (0))
		{
			SelectBuilding (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
		}
	}
	#endregion


	#region PUBLIC API

	#endregion


	#region HELPER FUNCTIONS
	void SelectBuilding (Vector2 position)
	{
		if (true) //TODO replace with UI not already displaying some UI
		{
			Ray ray = Camera.main.ScreenPointToRay(position);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, 100, Layers.BUILDINGS_MASK))
			{
				
			}
		}
	}
	#endregion
}
