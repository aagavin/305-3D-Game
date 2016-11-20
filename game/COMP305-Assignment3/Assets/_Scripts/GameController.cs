using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// private varables
	private int _score;
	private int _health;
	private int _amo;
	private bool _invulnerable;
	private GameObject[] Spawnpoints;
	private int _waveNum =1;
	private int _dalekSpawnCount;

	// public varables
	public Text ScoreText;
	public Text HelthText;
	public Text AmoText;
	public Transform Dalek;



	//test public
	public float invulnerableTime;

	//
	public int DalekSpawnCount {
		get{
			return _dalekSpawnCount;
		}
		set{
			this._dalekSpawnCount = value;
			if (this._dalekSpawnCount == 0) {
				this._waveNum++;
				this._spawnDaleks ();
			}
		}
	}

	public int Score {
		get{
			return this._score;
		}
		set{
			this._score = value;
			ScoreText.text = "Score: " + this._score;

		}
	}

	public int Health {
		get{
			return this._health;
		}
		set{
			this._health = value;
			HelthText.text = "Health: " + this.Health;
		}
	}

	public void HealthHit(){
		if (!this._invulnerable) {
			this.Health -= 10;
			this._setInvulnerable ();
		}
		
	}

	private void _setInvulnerable(){
		this._invulnerable = true;
		Invoke("_setVulnerable", invulnerableTime);

	}

	private void _setVulnerable(){
		this._invulnerable = false;
	}


	// Use this for initialization
	void Start () {
		this._invulnerable = false;
		this._health = 100;
		this.invulnerableTime = 1.5f;
		Spawnpoints = GameObject.FindGameObjectsWithTag ("Spawnpoint");
		this._spawnDaleks ();
	}

	private void _spawnDaleks(){
		this._dalekSpawnCount = this._waveNum * 3;

		for (int i = 0; i < (this._waveNum * 3); i++) {
			int rand = Random.Range (0, 4);
			Vector3 position = (Spawnpoints [rand]).transform.position;

			Instantiate (Dalek, position, Quaternion.identity);
		}
	}

}
