using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour 
{

	private float EnemiesRate;
	public List<GameObject> Enemies;
	public List<GameObject> SavedEnemies;

    public List<GameObject> PowerUp;
    public List<GameObject> SavedPower;

	private int Score;
	public Text UI_Score;

	public GameObject FinalBoss;
	private float GlobalRate;
    private float PowerUpRate;

    public GameObject Player;
    public Slider UI_Time;
    
    string CurrentScene;

	// Use this for initialization
	void Start () 
	{
        Player.GetComponent<PlayerControl>().Manager = GetComponent<GameManager>();
		GetScore (0);
        CurrentScene = SceneManager.GetActiveScene().name;

    }

	// Update is called once per frame
	void Update () 
	{
        if (CurrentScene == "Lvl1")
        {
            TimeWait();

            GlobalRate += Time.deltaTime;
            EnemiesRate += Time.deltaTime;
            PowerUpRate += Time.deltaTime;
            if (GlobalRate < 40f)
            {
                if (EnemiesRate > 0.3f)
                {
                    GameObject NewEnemy = (GameObject)Instantiate(Enemies[0], new Vector2(8.5f, Random.Range(-4.3f, 3.5f)), Quaternion.Euler(0, 0, 0));
                    SavedEnemies.Add(NewEnemy);
                    NewEnemy.GetComponent<EnemyControl>().Manager = GetComponent<GameManager>();
                    EnemiesRate = 0;
                }
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        } else if (CurrentScene == "Lvl2")
        {
            TimeWait();

            GlobalRate += Time.deltaTime;
            EnemiesRate += Time.deltaTime;
            PowerUpRate += Time.deltaTime;
            if (GlobalRate < 40f)
            {
                if (EnemiesRate > 0.3f)
                {
                    GameObject NewEnemy = (GameObject)Instantiate(Enemies[1], new Vector2(8.5f, Random.Range(-4.3f, 3.5f)), Quaternion.Euler(0, 0, 0));
                    SavedEnemies.Add(NewEnemy);
                    NewEnemy.GetComponent<EnemyControl>().Manager = GetComponent<GameManager>();
                    EnemiesRate = 0;
                }
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }

        if(CurrentScene == "Lvl3")
        {
            TimeWait();

		    GlobalRate += Time.deltaTime;
		    EnemiesRate += Time.deltaTime;
            PowerUpRate += Time.deltaTime;
		    if (GlobalRate < 40f)
            {
			    if (EnemiesRate > 0.3f)
                {
				    GameObject NewEnemy = (GameObject)Instantiate (Enemies [Random.Range (0, 2)], new Vector2 (8.5f, Random.Range (-4.3f, 3.5f)), Quaternion.Euler (0, 0, 0));
				    SavedEnemies.Add (NewEnemy);
				    NewEnemy.GetComponent<EnemyControl> ().Manager = GetComponent<GameManager> ();
				    EnemiesRate = 0;
			    }
		    } else 
		    {
			    FinalBoss.SetActive (true);
		    }
        }

        if (PowerUpRate > 5)
        {
            GameObject NewPowerUp = (GameObject)Instantiate(PowerUp[Random.Range(0, 2)], new Vector2(8.5f, Random.Range(-4.3f, 4.3f)), Quaternion.Euler(0, 0, 0));
            SavedPower.Add(NewPowerUp);
            NewPowerUp.GetComponent<PowerControl>().Manager = GetComponent<GameManager>();
            PowerUpRate = 0;
        }



	}

	public void GetScore(int score)
	{
		Score += score;
		UI_Score.text = "Score: " + Score.ToString();
	}

    public void TresDisparos()
    {
        Player.GetComponent<PlayerControl>().ShootAsist = true;
        Player.GetComponent<PlayerControl>().ShootSystem();
    }

    public void GetShield()
    {
        Player.GetComponent<PlayerControl>().ActiveShield = true;
        Player.GetComponent<PlayerControl>().PutShield();
    }

    public void TimeWait()
    {
        if (GlobalRate < 40)
        {
            UI_Time.GetComponent<Slider>().value = GlobalRate;
        }
        else
        {
            UI_Time.GetComponent<Slider>().value = 40;
 
        }
    }

}
