using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// local variables
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		// Prints mouse position in game units to the console
		print (mousePosInBlocks);

		// Allows movement of the paddle using mouse input
		// The Mathf.Clamp function restricts the paddle's movement to the following coordinates
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;

	}
}
