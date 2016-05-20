using UnityEngine;
using System.Collections;

public class ScreenWrapBall : MonoBehaviour {

	// Use this for initialization
	GameObject mainCamera;

	Renderer[] renderers;

	bool isWrappingX = false;
	bool isWrappingY = false;
	private int lifes = 1;

	// Use this for initialization
	void Start () {

		renderers = GetComponentsInChildren<Renderer>();

		mainCamera = GameObject.Find("MainCamera");
	}


	// Update is called once per frame
	void Update () {


		/* Versión 1 */
		Wrap();
		/* Versión 2 */
		//if (Input.GetMouseButton(0))
		//{
		//    var pos = Input.mousePosition;
		//    pos.z = Camera.main.transform.position.y;
		//    pos = Camera.main.ScreenToWorldPoint(pos);

		//    var targetRotation = Quaternion.LookRotation(pos - transform.position);
		//    transform.rotation = targetRotation;
		//    velocity = Vector3.Project(velocity, transform.forward);
		//    velocity += transform.forward * Time.deltaTime * force;
		//}


	}

	//void OnTriggerEnter(Collider src)
	//{
	//    System.Console.Write("Colisión");
	//} 
	void Wrap()
	{
		// If all parts of the object are invisible we wrap it around
		foreach (var renderer in renderers)
		{
			if (renderer.isVisible)
			{
				isWrappingX = false;
				isWrappingY = false;
				return;
			}
		}

		// If we're already wrapping on both axes there is nothing to do
		if (isWrappingX && isWrappingY)
		{
			return;
		}

		var cam = Camera.main;
		var newPosition = transform.position;

		// We need to check whether the object went off screen along the horizontal axis (X),
		// or along the vertical axis (Y).
		//
		// The easiest way to do that is to convert the ships world position to
		// viewport position and then check.
		//
		// Remember that viewport coordinates go from 0 to 1?
		// To be exact they are in 0-1 range for everything on screen.
		// If something is off screen, it is going to have
		// either a negative coordinate (less than 0), or
		// a coordinate greater than 1
		//
		// So, we get the ships viewport position
		var viewportPosition = cam.WorldToViewportPoint(transform.position);


		// Wrap it is off screen along the x-axis and is not being wrapped already
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			// The scene is laid out like a mirror:
			// Center of the screen is position the camera's position - (0, 0),
			// Everything to the right is positive,
			// Everything to the left is negative;
			// Everything in the top half is positive
			// Everything in the bottom half is negative
			// So we simply swap the current position with it's negative one
			// -- if it was (15, 0), it becomes (-15, 0);
			// -- if it was (-20, 0), it becomes (20, 0).
			newPosition.x = -newPosition.x;

			// If you had a camera that isn't at X = 0 and Y = 0,
			// you would have to use this instead
			// newPosition.x = Camera.main.transform.position - newPosition.x;

			isWrappingX = true;
		}
		// Wrap it is off screen along the y-axis and is not being wrapped already

		
		if (!isWrappingY && (viewportPosition.y < 0))
		{
			lifes--;
		}

		
		//Apply new position
		transform.position = newPosition;
	}

}
