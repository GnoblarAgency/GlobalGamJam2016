using UnityEngine;
using System.Collections;

public class DayNightEffect : MonoBehaviour {

	public Light dayLight;


	private float daytime = 0;
	private int reverse = 1;

	void Update () 
	{
		
		daytime += Time.deltaTime*reverse;

		dayLight.intensity = Mathf.Min( daytime, 1.5f); 

		if (daytime >= ResourcesManager.TICK_DELAY/2.0f)
		{
			reverse = -1;
		}
		else if (daytime <= 0)
		{
			reverse = 1;
		}
	}
}
