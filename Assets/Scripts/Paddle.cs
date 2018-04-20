using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if (autoPlay == false){
			MoveWithMouse();
		} else{
			AutoPlay();
		}

	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x,0.5f,15.5f);
		
		this.transform.position = paddlePos;
	}

	void MoveWithMouse(){
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
