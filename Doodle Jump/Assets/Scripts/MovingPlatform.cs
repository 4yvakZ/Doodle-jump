using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private float movingSpeed = 5f;
    private bool isVertical;
    private int direction = 1;

    void Start()
    {
        isVertical = Random.Range(0, 2) == 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (isVertical)
        {

        }
       // if (transform.position.)
    }
}
