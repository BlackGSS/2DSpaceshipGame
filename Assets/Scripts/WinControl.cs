using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinControl : MonoBehaviour
{
    private float CountMenu;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CountMenu += Time.deltaTime;
        if (CountMenu > 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
