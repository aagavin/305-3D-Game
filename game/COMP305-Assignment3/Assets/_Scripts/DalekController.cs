using UnityEngine;
using System.Collections;

public class DalekController : MonoBehaviour {

	//private varables
	private Transform _transform;

	// public varable
	public GameObject ScoreBoardController;



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

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	private void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player") ){
			Debug.Log (other.gameObject.tag + System.DateTime.Now);
			ScoreBoardController.GetComponent<ScoreBoardController> ().HealthHit ();

		}

	}
}
