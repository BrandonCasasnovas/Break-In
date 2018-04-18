using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector; 
	public bool hasStarted = false;
	private Rigidbody2D rigi;

	private void Awake(){
		rigi = GetComponent<Rigidbody2D>(); 
	}

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		// Ties the ball's position to the paddle's vector position
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			if (!hasStarted){
				// Lock the ball relative to the paddle
				this.transform.position = paddle.transform.position + paddleToBallVector;
			
				// Wait for mouse press to launch
				if (Input.GetMouseButtonDown(0)) {
					print("mouse clicked LAUNCH BALL");
					// Checks if game has "started" so the ball can be untied from the paddle
					hasStarted = true;
					rigi.velocity = new Vector2(2f, 10f);		
				}
			}	
		}
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource audio = GetComponent<AudioSource>();
		if(hasStarted){
		audio.Play();
		}
	}
}
