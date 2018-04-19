using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unbreakableBrick : MonoBehaviour {

	public AudioClip tink;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint(tink, transform.position, 0.2f);
		

	}
}
