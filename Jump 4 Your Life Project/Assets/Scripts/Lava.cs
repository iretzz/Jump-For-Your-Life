using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float lavaRiseSpeed = 150;
    public bool isRising = true;
    // public PlayerController playerController;

    void Start()
    {
        // playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isRising == true)
        {
            transform.Translate(0, lavaRiseSpeed / 60 * Time.deltaTime, 0);
        }
        if (isRising == false)
        {
            transform.Translate(0, -lavaRiseSpeed / 50, 0);
        } 
    }
}
