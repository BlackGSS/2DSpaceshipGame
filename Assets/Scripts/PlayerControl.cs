using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour {

	public float Speed;

	public GameObject Bullet;
    public GameObject AuxBullet;
    public GameObject AuxBullet2;
	private float ContadorShoot;

    public GameManager Manager;

    public bool ShootAsist;
    public float ContadorTriple;

    public float ContadorShield;
    public bool ActiveShield;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Movimiento ();
        ShootSystem();
        PutShield();

    }
	public void Movimiento()
	{

		transform.Translate (Vector3.up * Input.GetAxis ("Vertical") * Speed * Time.deltaTime);

		if (transform.position.x > 6)
		{
			transform.position = new Vector2(6, transform.position.y);
		}
		if (transform.position.x < -6)
		{
			transform.position = new Vector2(-6, transform.position.y);
		}

		if (transform.position.y > 4.3f)
		{
			transform.position = new Vector2(transform.position.x, 4.3f);
		}
		if (transform.position.y < -4.3f)
		{
			transform.position = new Vector2(transform.position.x, -4.3f);
		}

	}

	public void ShootSystem()
	{
		ContadorShoot += Time.deltaTime;
        if (ContadorShoot > 0.2f) 
		{
                if(ShootAsist == true)
                {
                ContadorTriple += Time.deltaTime;
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (ContadorTriple < 3)
                        {
                            GameObject NewAuxBullet2 = (GameObject)Instantiate(AuxBullet2, new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0));
                            GameObject NewAuxBullet = (GameObject)Instantiate(AuxBullet, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), Quaternion.Euler(0, 0, 0));
                            GameObject NewBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
                            Destroy(NewBullet, 2);
                            Destroy(NewAuxBullet, 2);
                            Destroy(NewAuxBullet2, 2);
                            ContadorShoot = 0;
                        }
                        else
                        {
                            ShootAsist = false;
                            ContadorTriple = 0;
                        }
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        GameObject NewBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
                        Destroy(NewBullet, 3);
                        ContadorShoot = 0;
                    }
                }
		}
		
	}

	void OnTriggerEnter2D(Collider2D Col)
	{

		if (Col.tag == "EnemyBullet" || Col.tag == "Enemy") 
		{
            if (transform.GetChild(0).gameObject.activeSelf != true)
            {
                SceneManager.LoadScene(2);
            }
        }
	}

    public void PutShield()
    {
        if(ActiveShield == true)
        {
            ContadorShield += Time.deltaTime;
            if (ContadorShield < 4)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                ActiveShield = false;
                ContadorShield = 0;
            }
        }
    }

}
