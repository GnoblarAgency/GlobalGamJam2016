using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{

	// Use this for initialization
	public void LoadScene (int level) 
	{
		Application.LoadLevel(level);
	}

}
