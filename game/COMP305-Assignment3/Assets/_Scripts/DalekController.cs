using UnityEngine;
using System.Collections;

public class DalekController : MonoBehaviour {

	//private varables
	private Transform _player;
	private GameObject _scoreBoardController;
	private int _life;

	// public varable
	public NavMeshAgent Agent;


	public int Life {
		get{
			return this._life;
		}
		set{
			this._life = value;
			if(this._life==0){
				GameObject.Destroy (this.gameObject);
			}
		}
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		this._scoreBoardController = GameObject.FindGameObjectWithTag ("ScoreBoard");
		this._player = GameObject.FindWithTag ("Player").transform;
		this._life = 2;
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
			other.gameObject.GetComponent<Rigidbody> ().velocity *=-500;

			Debug.Log (other.gameObject.tag + System.DateTime.Now);
			_scoreBoardController.GetComponent<GameController> ().HealthHit ();

		}

	}
}
