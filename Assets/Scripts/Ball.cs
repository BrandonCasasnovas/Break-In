using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public AudioClip bounce;
	private Paddle paddle;
	private Vector3 paddleToBallVector; 
	public bool hasStarted = false;
	private Rigidbody2D rigi;
	

	private void Awake(){
		// allows us to use the rigidbody compnent without having to use the GetCompenent method every time
		rigi = GetComponent<Rigidbody2D>(); 
	}

	// Use this for initialization
	void Start () {
		// grabs the paddle object
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
		// defines adjustment to ball's speed using a random float beteen 0 and 0.2 to so that the game isnt always at the same boring speed
		Vector2 tweak = new Vector2 (Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		float ballVelocity = GetComponent<Rigidbody2D>().velocity.magnitude;
			// Regulates the ball's speed not letting it speed up to infinity and doesn't let it come to a dead slow state
			if (ballVelocity <= 7){
				rigi.velocity = rigi.velocity.normalized * 7;
			}
			else if (ballVelocity >= 12){
				rigi.velocity = rigi.velocity.normalized * 12;
			}
		
			if(hasStarted){
				// doesnt allow the ball 'bounce' to play audio if it hits a crackable brick only on 1 hits, paddle, and walls, and unbreakable bricks
				if(!collision.gameObject.GetComponent<Brick>() || !collision.gameObject.GetComponent<Brick>().isBreakable || !collision.gameObject.GetComponent<UnbreakableBrick>().isUnBreakable){
						AudioSource.PlayClipAtPoint(bounce, transform.position,0.4f);
						rigi.velocity  += tweak;
				}
					
				}
				
	}
}
