using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	//
	public Text GameOverText;
	public Button RestartButton;

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


	/// <summary>
	/// Hit function
	/// </summary>
	public void HealthHit(){
		if (!this._invulnerable) {
			this.Health -= 10;
			if (this.Health == 0) {
				//sound for game over

				//
				Time.timeScale=0;
//				GameObject.FindGameObjectWithTag ("Player").SetActive(false);

				this.ScoreText.gameObject.SetActive(false);
				this.HelthText.gameObject.SetActive(false);
				this.AmoText.gameObject.SetActive(false);

				GameOverText.gameObject.SetActive(true);
				RestartButton.gameObject.SetActive(true);

				int highScore = PlayerPrefs.GetInt ("HighScore");
				if (this._score > highScore) {
					PlayerPrefs.SetInt ("HighScore", this._score);
				}
				GameOverText.text="Game Over High Score: "+PlayerPrefs.GetInt ("HighScore");
				Cursor.lockState = CursorLockMode.None;

			}
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

		// hide end game stuff
		GameOverText.gameObject.SetActive(false);
		RestartButton.gameObject.SetActive(false);
		PlayerPrefs.SetInt ("HighScore", 0);
	}

	private void _spawnDaleks(){
		this._dalekSpawnCount = this._waveNum * 3;

		for (int i = 0; i < (this._waveNum * 3); i++) {
			int rand = Random.Range (0, 4);
			Vector3 position = (Spawnpoints [rand]).transform.position;

			Instantiate (Dalek, position, Quaternion.identity);
		}
	}


	public void Reset(){
		int highScore = PlayerPrefs.GetInt ("HighScore");
		if (this._score > highScore) {
			PlayerPrefs.SetInt ("HighScore", this._score);
		}
	
		Time.timeScale = 1;

		SceneManager.LoadScene (0);
	}

}
