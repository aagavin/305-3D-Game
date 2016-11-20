using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {

	//private
	private Transform _transform;

	//public
	public AudioSource Firesound;
	public Transform FirePosition;
	public GameObject FireEffect;
	public AudioSource HealthSound;

	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {

			Firesound.volume = .1f;
			Firesound.Play ();

			GameObject fe = (GameObject) GameObject.Instantiate (FireEffect, FirePosition.position,FirePosition.rotation);
			fe.transform.parent = FirePosition;

			RaycastHit hit;
			if (Physics.Raycast (this._transform.position, this._transform.forward, out hit)) {
				if (hit.transform.gameObject.CompareTag ("Enemy")) {
					hit.transform.gameObject.GetComponent<DalekController> ().Life -= 1;
				}
			}

			GameObject.Destroy (fe, 2f);

		}
	}

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Pickup")){
			HealthSound.Play ();
			GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController>().Health+=5;
			GameObject.Destroy (other.gameObject);
		}
	}
}
