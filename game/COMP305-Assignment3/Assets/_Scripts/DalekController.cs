using UnityEngine;
using System.Collections;

public class DalekController : MonoBehaviour {

	//private varables
	private Transform _player;
	private GameObject _scoreBoardController;

	// public varable
	public NavMeshAgent Agent;


	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		this._scoreBoardController = GameObject.FindGameObjectWithTag ("ScoreBoard");
		this._player = GameObject.FindWithTag ("Player").transform;
	}

	void Update(){
		this.Agent.SetDestination (this._player.position);
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	private void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player") ){
			Debug.Log (other.gameObject.tag + System.DateTime.Now);
			_scoreBoardController.GetComponent<GameController> ().HealthHit ();

		}

	}
}
