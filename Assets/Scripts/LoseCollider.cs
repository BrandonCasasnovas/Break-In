using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
		
	public int lives = 3;
	private Ball ball;
	private Paddle paddle;
	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		
		lives--;
		if (lives == 0){
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("Lose");
		} else {
				ball = GameObject.FindObjectOfType<Ball>();
				paddle = GameObject.FindObjectOfType<Paddle>();
				ball.hasStarted = false;
				ball.transform.position = new Vector3(paddle.transform.position.x, 0f);
			}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		print ("collision");
	}
}
