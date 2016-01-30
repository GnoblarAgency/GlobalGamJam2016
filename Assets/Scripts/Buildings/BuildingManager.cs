using UnityEngine;
using System.Collections;

public sealed class BuildingManager : MonoBehaviour
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
		if (!UIManager.instance.IsScreenVisible())
		{
			Ray ray = Camera.main.ScreenPointToRay(position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 10000, Layers.BUILDINGS_MASK))
			{
				Building building = hit.collider.GetComponent<Building>();
				if (building == null)
				{ building = hit.collider.GetComponentInParent<Building> (); }
					
				if (building.IsClickable)
				{
					building.OpenUI();
				}
			}
		}
	}
	#endregion
}
