using UnityEngine;
using System.Collections;

public class DalekController : MonoBehaviour {

<<<<<<< HEAD
	//private varables
	private Transform _transform;

	// public varable
	public GameObject ScoreBoardController;

=======

	// public varable
	public Transform _transform;
>>>>>>> c57f8624c52874158a3edb5d8320ea6d28295f5f

	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
	}
	
	/// <summary>
	/// Fixed update runs every frame
	/// </summary>
	void FixedUpdate () {
		this._transform.Translate (Vector3.forward * (Time.deltaTime*2));
	}

<<<<<<< HEAD
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	private void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player") ){
			Debug.Log (other.gameObject.tag + System.DateTime.Now);
			ScoreBoardController.GetComponent<ScoreBoardController> ().HealthHit ();

		}
=======
	private void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.tag);
>>>>>>> c57f8624c52874158a3edb5d8320ea6d28295f5f
	}
}
