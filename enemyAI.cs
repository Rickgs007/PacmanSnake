using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {

	public int 			z = 0;
	public float 		enemyVelo = 0.02f;

	private float 		x;
	private float 		y;
	private float 		eneX;
	private float 		eneY;
	private float 		playX;
	private float 		playY;
	private float 		absDistX;
	private float 		absDistY;
	private float 		dirX;
	private float		dirY; 
	private bool 		moveX;
	private bool 		moveY;
	private GameObject 	player; 
	private Vector3 	posPlayer;


	void Start () {
		player = GameObject.FindWithTag ("Player");
	}


	void Update () {
		
// Follow Player:

		posPlayer = player.transform.position;

		playX = posPlayer.x;
		playY = posPlayer.y;

		eneX = transform.position.x;
		eneY = transform.position.y;

		absDistX = Mathf.Abs (playX - eneX);
		absDistY = Mathf.Abs (playY - eneY);
			
		// Moving:

		if (absDistX > 0) {
			if (eneX > playX) {
				dirX = -1;
			} else if (eneX < playX) {
				dirX = 1;
			}
			x = transform.position.x + enemyVelo * dirX;
		}

		if (absDistY > 0) {
			if (eneY > playY) {
				dirY = -1;
			} else if (eneY < playY) {
				dirY = 1;
			}
			y = transform.position.y + enemyVelo * dirY;
		}

		transform.position = new Vector3 (x, y, z);
	}
}
