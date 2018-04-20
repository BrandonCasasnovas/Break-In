using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableBrick : MonoBehaviour {

	public AudioClip tink;
	public bool isUnBreakable; 

	// Use this for initialization
	void Start () {
		isUnBreakable = (this.tag == "unreakable");
	}
	
	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint(tink, transform.position, 0.2f);
	}
}
