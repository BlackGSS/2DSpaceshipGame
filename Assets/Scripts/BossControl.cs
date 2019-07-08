using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BossControl : MonoBehaviour 
{

	public float Speed; 

	private int PosIni = 5;
	private int PosUp = 2;
	private int PosDown = -2;
	public bool Sube = false;

    private float ContadorShoot;
    public GameObject Bullet;

    public Image EnemyLifeBar;
    private int EnemyLife = 100;

	// Use this for initialization
	void Start () 
	{

    }
	
	// Update is called once per frame
	void Update () 
	{

        if (gameObject.activeSelf == true) 
		{
            if (transform.position.x != PosIni) 
			{
				transform.position = Vector2.MoveTowards (transform.position, new Vector2 (5, transform.position.y), Speed * Time.deltaTime);
				Sube = true;
			} 
			else 
			{
				if (Sube == true) {
					if (transform.position.y != PosUp) {
						transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, 2), Speed * Time.deltaTime);
                        ShootSystem();
                    }
                    else
                    {
                        Sube = false;
                    }
				} else {
					if (transform.position.y != PosDown) {
						transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, -2), Speed * Time.deltaTime);
                        ShootSystem();
                    }
                    else
                    {
                        Sube = true;
                    }
				}
			}
		}
        if (EnemyLife == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(6);
        }
    
	}

    public void ShootSystem()
    {
        ContadorShoot += Time.deltaTime;
        if (ContadorShoot > 0.6f)
        {
            GameObject NewBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(NewBullet, 4);
            ContadorShoot = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Bullet")
        {
            EnemyLife = EnemyLife - 1;
            EnemyLifeBar.fillAmount = (float)EnemyLife / 100;
        }
    }
}
