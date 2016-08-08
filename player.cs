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
	private int 		fruits;
	private int 		totalFruits;
	private GameObject 	enemy;
	private GameObject 	fruit;
	//private GameObject 	finalFruit;

	void Start () {
		enemy = 		GameObject.FindWithTag ("Enemy");
		fruit = 		GameObject.FindWithTag ("Fruit");
		//finalFruit = 	GameObject.FindWithTag ("Final Fruit");
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
		fruitSpawnX = Random.Range (limitX, - limitX);
		fruitSpawnY = Random.Range (limitY, - limitY);

		if (col.gameObject.tag == "Fruit") {
			// Creates Enemies:
			Instantiate (enemy, new Vector3 (eneSpawnX, eneSpawnY, z), Quaternion.identity); 

			// if (fruits < totalFruits)

			fruit.transform.position = new Vector3 (fruitSpawnX, fruitSpawnY, z);
	

			// else if (fruits == totalfruits) 
			// DEstroy fruit and Instantiate finalFruit

			/*if (fruits < totalFruits) {
				Instantiate (fruit, new Vector3 (fruitSpawnX, fruitSpawnY, z), Quaternion.identity);
			} else if (fruits == totalFruits) {
				Instantiate (finalFruit, new Vector3 (fruitSpawnX, fruitSpawnY, z), Quaternion.identity);
			}*/
		}

// Enemy:
		if (col.gameObject.tag == "Enemy") {
			Debug.Log ("UOOOU");
			SceneManager.LoadScene ("GameOver");
		}

	}


}
