using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoControl : MonoBehaviour
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
        if(transform.localPosition.x < -798)
        {
            transform.localPosition = new Vector3(798, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
