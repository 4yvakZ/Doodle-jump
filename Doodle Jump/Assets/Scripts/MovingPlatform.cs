using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float movingRange = 2f;
    private bool isVertical;
    private bool movingForward = true;
    private Vector3 initialPos;

    void Start()
    {
        isVertical = Random.Range(0, 2) == 1;
        initialPos = transform.position;
        if (!isVertical)
        {
            if (initialPos.x > 0)
            {
                movingForward = false;
                initialPos.x -= movingRange / 2;
            } 
            else
            {
                initialPos.x += movingRange / 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isVertical)
        {
            if (movingForward)
            {
                if (transform.position.y < initialPos.y + movingRange / 2)
                {
                    transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
                }
                else
                {
                    movingForward = false;
                }
            } 
            else
            {
                if (transform.position.y > initialPos.y - movingRange / 2)
                {
                    transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
                }
                else
                {
                    movingForward = true;
                }
            }
        } 
        else
        {
            if (movingForward)
            {
                if (transform.position.x < initialPos.x + movingRange / 2)
                {
                    transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
                }
                else
                {
                    movingForward = false;
                }
            }
            else
            {
                if (transform.position.x > initialPos.x - movingRange / 2)
                {
                    transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
                }
                else
                {
                    movingForward = true;
                }
            }
        }
    }
}
