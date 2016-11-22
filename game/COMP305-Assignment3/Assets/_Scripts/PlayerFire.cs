using UnityEngine;
using System.Collections;

/*
 * Pedro Bento
 * Aaron Fernandes - 300773526
 * 
 * COMP 305 - Assignment 3
 */ 



/// <summary>
/// Player fire.
/// </summary>
public class PlayerFire : MonoBehaviour {

	/************** PRIVATE VARABLES **************/
	private Transform _transform;

	/************** PUBLIC  VARABLES **************/
	public AudioSource Firesound;
	public Transform FirePosition;
	public GameObject FireEffect;
	public AudioSource HealthSound;


	/************** PRIVATE FUNCTIONS  **************/
	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			if (GameObject.FindGameObjectWithTag ("ScoreBoard").GetComponent<GameController> ().Amo < 100) {


				Firesound.volume = .1f;
				Firesound.Play ();

				GameObject fe = (GameObject)GameObject.Instantiate (FireEffect, FirePosition.position, FirePosition.rotation);
				fe.transform.parent = FirePosition;

				RaycastHit hit;
				if (Physics.Raycast (this._transform.position, this._transform.forward, out hit)) {
					if (hit.transform.gameObject.CompareTag ("Enemy")) {
						hit.transform.gameObject.GetComponent<DalekController> ().Life -= 1;
					}
				}

				GameObject.Destroy (fe, 2f);
				GameObject.FindGameObjectWithTag ("ScoreBoard").GetComponent<GameController> ().Amo+=10;

			} 

		}
	}

	/************** PUBLIC FUNCTIONS **************/

	/// <summary>
	/// Raises the collision enter event.
	/// This occours when player hits pickup
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Pickup")){
			HealthSound.Play ();
			GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController>().Health+=5;
			GameObject.Destroy (other.gameObject);
		}
	}
}
