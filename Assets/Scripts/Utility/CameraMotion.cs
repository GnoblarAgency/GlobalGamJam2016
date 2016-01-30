﻿using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {
	
	float ScrollSpeed = 40;
	float ScrollEdge = 0.01f;

	private int HorizontalScroll = 1;
	private int VerticalScroll = 1;
	private int DiagonalScroll = 1;

	float PanSpeed = 50;

	Vector2 ZoomRange;
	float CurrentZoom = 0;
	float ZoomZpeed = 1;
	float ZoomRotation = 1;

	private Vector3 InitPos;
	private Vector3 InitRotation;



	void Start()
	{
		//Instantiate(Arrow, Vector3.zero, Quaternion.identity);
		ZoomRange = new Vector2(-50,50);
		InitPos = transform.position;
		InitRotation = transform.eulerAngles;

	}

	void Update ()
	{
		//PAN
		if ( Input.GetKey("mouse 2") )
		{
			//(Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5)
			if (transform.position.z > 320 && transform.position.x < 420 && transform.position.z > 120 && transform.position.z < 220)
			transform.Translate(transform.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5f)/(Screen.width * 0.5f), Space.World);

			if (transform.position.z > 120 && transform.position.z < 220 && transform.position.z > 320 && transform.position.x < 420)
			transform.Translate(transform.forward * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5f)/(Screen.height * 0.5f), Space.World);

		}
		else
		{
			if ( Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge) )
			{
				transform.Translate(transform.right * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge )
			{
				transform.Translate(transform.right * Time.deltaTime * -ScrollSpeed, Space.World);
			}

			if ( Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge) )
			{
				transform.Translate(transform.forward * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge )
			{
				transform.Translate(transform.forward * Time.deltaTime * -ScrollSpeed, Space.World);
			}
		}

		//ZOOM IN/OUT

		CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

		CurrentZoom = Mathf.Clamp(CurrentZoom,ZoomRange.x,ZoomRange.y);
		Vector3 temp = new Vector3 (transform.position.x, transform.position.y - (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1f, transform.position.z);
		transform.position = temp;
	//	transform.eulerAngles.x -= (transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;

	}
}