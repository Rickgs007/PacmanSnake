using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public float 		velo = 0.1f;
	public float 		limitX;
	public float 		limitY;
	public int 			z = 0;

	private float 		aX;
	private float 		aY;
	private float	 	x;
	private float 		y;
	public float 		eneSpawnX;
	public float 		eneSpawnY;
	private float 		fruitSpawnX;
	private float 		fruitSpawnY;
	private int 		fruits = 0;
	public int 		totalFruits;
	private GameObject 	enemy;
	private GameObject 	fruit;
	private GameObject 	finalFruit;

	void Start () {
		enemy = 		GameObject.FindWithTag ("Enemy");                       // Use the Prefab!!!
		fruit = 		GameObject.FindWithTag ("Fruit");
		finalFruit = 	GameObject.FindWithTag ("FinalFruit"); 
	}

	 
	void Update () {
		
// Movement:
		aX = Input.GetAxis ("Horizontal");
		aY = Input.GetAxis ("Vertical");
		x = transform.position.x + velo * aX;
		y = transform.position.y + velo * aY;

		transform.position = new Vector3 (x, y, z);
	}
		

	void OnCollisionEnter2D (Collision2D col) {
	
// Fruit:
		if (col.gameObject.tag == "Fruit") {
			
			fruits += 1;

		// Spawn Position:
			fruitSpawnX = Random.Range (limitX, - limitX);
			fruitSpawnY = Random.Range (limitY, -limitY); 
			eneSpawnX = -fruitSpawnX;                                      // Put it far from the player!!!
			eneSpawnY = -fruitSpawnY;


		// 'New' Fruits:
			if (fruits < totalFruits) {
				
				fruit.transform.position = new Vector3 (fruitSpawnX, fruitSpawnY, z);
			} else if (fruits == totalFruits) {
				Destroy (fruit);
				Instantiate (finalFruit, new Vector3 (fruitSpawnX, fruitSpawnY, z), Quaternion.identity);
			}
		
		// Creates Enemies:
			Instantiate (enemy, new Vector3 (eneSpawnX, eneSpawnY, z), Quaternion.identity); 
		}

//FinalFruit:
		if (col.gameObject.tag == "FinalFruit") {
			
		//You Won:
			SceneManager.LoadScene ("YouWon");
		}

// Enemy:
		if (col.gameObject.tag == "Enemy") {
			
		// Game Over:
			SceneManager.LoadScene ("GameOver");
		}

// Restart:
		if (col.gameObject.tag == "Restart") {
			
			SceneManager.LoadScene ("SnakeMan1");
		}

	}


}
