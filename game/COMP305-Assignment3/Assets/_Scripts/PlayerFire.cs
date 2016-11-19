using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {


	//public
	public AudioSource Firesound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			Firesound.Play ();
		}
	}
}
