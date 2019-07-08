using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour 
{

	public float Speed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(transform.tag == "Bullet")
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if(transform.tag == "AuxBullet1")
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 3, transform.position.y + 1), Speed * Time.deltaTime);

        }

        if(transform.tag == "AuxBullet2")
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 3, transform.position.y - 1), Speed * Time.deltaTime);
        }
    }

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.tag == "Enemy") 
		{
			Destroy (gameObject);
		}
	}
}
