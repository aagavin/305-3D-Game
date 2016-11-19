using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;

public class ScoreBoardController : MonoBehaviour {

	// private varables
	private int _score;
	private int _health;
	private int _amo;
	private bool _invulnerable;

	// public varables
	public Text ScoreText;
	public Text HelthText;
	public Text AmoText;

	//test public
	public float invulnerableTime;

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

	}

}
