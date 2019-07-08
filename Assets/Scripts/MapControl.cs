using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapControl : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public GameObject Waypoint3;
    public float Speed;

    // Use this for initialization
    void Start()
    {
        transform.position = Waypoint1.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && transform.position.x == Waypoint1.transform.position.x)
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Return) && transform.position.x == Waypoint2.transform.position.x)
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKeyDown(KeyCode.Return) && transform.position.x == Waypoint3.transform.position.x)
        {
            SceneManager.LoadScene(5);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < Waypoint2.transform.position.x)
        {
            for (int i = 0; transform.position.x < Waypoint2.transform.position.x; i++)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Waypoint2.transform.position.x, transform.position.y), Speed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < Waypoint3.transform.position.x)
            {
                for (int i = 0; transform.position.x < Waypoint3.transform.position.x; i++)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Waypoint3.transform.position.x, transform.position.y), Speed * Time.deltaTime);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > Waypoint2.transform.position.x)
        {
            for (int i = 0; transform.position.x > Waypoint2.transform.position.x; i++)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Waypoint2.transform.position.x, transform.position.y), Speed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > Waypoint1.transform.position.x)
            {
                for (int i = 0; transform.position.x > Waypoint1.transform.position.x; i++)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Waypoint1.transform.position.x, transform.position.y), Speed * Time.deltaTime);
                }
            }
        }
    }
}
