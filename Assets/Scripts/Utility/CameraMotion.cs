using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {
	
	float ScrollSpeed = 110;
	float ScrollEdge = 0.01f;

	int ScrollDistanceFromCentre = 180;

	private int HorizontalScroll = 2;
	private int VerticalScroll = 2;
	private int DiagonalScroll = 2;

	float PanSpeed = 1000;

	Vector2 ZoomRange;
	float CurrentZoom = 0;
	float ZoomZpeed = 1;
	float ZoomRotation = 1.3f;

	private Vector3 InitPos;
	private Vector3 InitRotation;


	void Start()
	{
		//Instantiate(Arrow, Vector3.zero, Quaternion.identity);
		ZoomRange = new Vector2(-50,50);
		InitPos = transform.position;
		InitRotation = transform.eulerAngles;

	}

	bool IsCamInBounds ()
	{
		return (transform.position.z > -135 && transform.position.z < 260 && transform.position.x < 565 && transform.position.x > 267);
	}
	void ClampCamToBounds ()
	{
		float x = Mathf.Clamp (transform.position.x, 267+2, 565-2);
		float z = Mathf.Clamp (transform.position.z, -50+2, 260-2);

		Vector3 pos = transform.position;
		pos.x = x;
		pos.z = z;

		transform.position = pos;
	}

	void Update ()
	{
		//PAN
		if ( Input.GetKey("mouse 1") )
		{
			//(Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5)
			if (Vector3.Distance(transform.position, InitPos) < 20)
			transform.Translate(transform.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5f)/(Screen.width * 0.5f), Space.World);

			if (Vector3.Distance(transform.position, InitPos) < 20)
			transform.Translate(transform.forward * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5f)/(Screen.height * 0.5f), Space.World);

		}
		else
		{
			/*if ( (Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge)) 
				&&  (Vector3.Distance(transform.position+(transform.right * Time.deltaTime * ScrollSpeed), InitPos) < ScrollDistanceFromCentre) )
			{
				transform.Translate(transform.right * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( (Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge) 
				&&  (Vector3.Distance(transform.position+(transform.right * Time.deltaTime * -ScrollSpeed), InitPos) < ScrollDistanceFromCentre) )
			{
				transform.Translate(transform.right * Time.deltaTime * -ScrollSpeed, Space.World);
			}

			if ( (Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge)) 
				&&  (Vector3.Distance(transform.position+(transform.forward * Time.deltaTime * ScrollSpeed), InitPos) < ScrollDistanceFromCentre) )
			{
				transform.Translate(transform.forward * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( (Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge) 
				&&  (Vector3.Distance(transform.position+(transform.forward * Time.deltaTime * -ScrollSpeed), InitPos) < ScrollDistanceFromCentre) )
			{
				transform.Translate(transform.forward * Time.deltaTime * -ScrollSpeed, Space.World);
			}*/
			if ( (Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge)) 
				&& IsCamInBounds ())
			{
				transform.Translate(transform.right * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( (Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge) 
				&& IsCamInBounds ())
			{
				transform.Translate(transform.right * Time.deltaTime * -ScrollSpeed, Space.World);
			}

			if ( (Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge)) 
				&& IsCamInBounds ())
			{
				transform.Translate(transform.forward * Time.deltaTime * ScrollSpeed, Space.World);
			}
			else if ( (Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge) 
				&& IsCamInBounds ())
			{
				transform.Translate(transform.forward * Time.deltaTime * -ScrollSpeed, Space.World);
			}
		}

		//ZOOM IN/OUT

		CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

		CurrentZoom = Mathf.Clamp(CurrentZoom,ZoomRange.x,ZoomRange.y);
		Vector3 temp = new Vector3 (transform.position.x, transform.position.y - (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1f, transform.position.z);
		transform.position = temp;
		temp = new Vector3(transform.eulerAngles.x -(transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation) * 0.1f), transform.eulerAngles.y, transform.eulerAngles.z);

		transform.eulerAngles = temp;

		ClampCamToBounds();

	}

	
}
