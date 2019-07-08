using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour 
{

	public float Speed;
	public GameManager Manager;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.left * Speed * Time.deltaTime);
		if (transform.position.x < -8f) 
		{
			DeleteEnemy ();
		}
	}

	void DeleteEnemy()
	{
		Manager.SavedEnemies.Remove (gameObject);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.tag == "Bullet" || Col.tag == "AuxBullet1" || Col.tag == "AuxBullet2") 
		{
			DeleteEnemy();
			Manager.GetScore(5);
		}
	}
}
