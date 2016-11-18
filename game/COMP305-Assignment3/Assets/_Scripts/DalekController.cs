using UnityEngine;
using System.Collections;

public class DalekController : MonoBehaviour {


	// public varable
	public Transform _transform;

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

	private void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.tag);
	}
}
