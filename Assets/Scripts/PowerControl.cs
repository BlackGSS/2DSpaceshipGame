using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerControl : MonoBehaviour
{

    public float Speed;
    public GameManager Manager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
        if (transform.position.x < -8f)
        {
            DeletePower();
        }

    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Bullet")
        {
            if(transform.tag == "Triple")
            {
                Manager.TresDisparos();
                DeletePower();
            }
            if (transform.tag == "Shield")
            {
                Manager.GetShield();
                DeletePower();
            }
        }
    }

    public void DeletePower()
    {
        Manager.SavedEnemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
