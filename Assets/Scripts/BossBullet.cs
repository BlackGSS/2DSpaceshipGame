using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
