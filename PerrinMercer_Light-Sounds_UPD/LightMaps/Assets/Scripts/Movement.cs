using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode rightKey;
	public KeyCode leftKey;

	public float speed = 16;

	public GameObject lightWallPrefab;

	Collider2D wall;

	//Last wall's end
	Vector2 lastWallEnd;

	// Use this for initialization
	void Start () {
		//Initial Velocity for player objects
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

		SpawnWall();
	
	}

	void OnTriggerEnter2D(Collider2D co) {

		if (co != wall){
			print("Collide");
			int rand = Random.Range(0, 4);
			switch (rand) {
				case 0:
					PureData.PlaySequence("Note_One");
					break;
				case 1:
					PureData.PlaySequence("Note_Two");
					break;
				case 2:
					PureData.PlaySequence("Note_Three");
					break;
				case 3:
					PureData.PlaySequence("Note_Four");
					break;
				default:
					break;
				}

		}
	}

	void SpawnWall(){

		//Save Last Wall's position
		lastWallEnd = transform.position;

		//Spawn new lightwall	
		GameObject g = (GameObject)Instantiate(lightWallPrefab, transform.position, Quaternion.identity);
		wall = g.GetComponent<Collider2D>();

	}

	void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b) {

		//Center Position calc
		co.transform.position = a + (b - a) *0.5f;

		//Scale horiz or vertically
		float dist = Vector2.Distance(a, b);
		if (a.x != b.x)
			co.transform.localScale = new Vector2(dist + 1, 1);
		else
			co.transform.localScale = new Vector2(1, dist + 1);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(upKey)){

			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

			SpawnWall();

		}
		else if (Input.GetKeyDown(downKey)){

			GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;

			SpawnWall();

		}
		else if (Input.GetKeyDown(rightKey)){

			GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

			SpawnWall();

		}
		else if (Input.GetKeyDown(leftKey)){

			GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;

			SpawnWall();

		}

		fitColliderBetween(wall, lastWallEnd, transform.position);
	
	}

	void OnBecameInvisible() {
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;
        Vector2 pos = gameObject.transform.position;
        if (vel.x != 0) {
        	pos.x *= -1;
        	pos.y -= 2;
        } else if (vel.y != 0){
        	pos.y *= -1;
        	pos.x -= 2;
        }
        gameObject.transform.position = pos;
        SpawnWall();
        print(gameObject.transform.position.x + ", " + gameObject.transform.position.y);
    }
}
