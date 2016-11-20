using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {


	//public
	public AudioSource Firesound;
	public Transform FirePosition;
	public GameObject FireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			Firesound.Play ();

			GameObject fe = (GameObject)Instantiate (FireEffect, FirePosition.position,FirePosition.rotation);
			fe.transform.parent = FirePosition;
			GameObject.Destroy (fe, 2f);

		}
	}
}
