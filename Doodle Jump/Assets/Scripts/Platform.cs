using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = GenerateNewPos();
    }

    private Vector3 GenerateNewPos()
    {
        Vector3 newPos = new Vector3();

        newPos.x = Random.Range(-GameManager.Instance.PlatformXRange, GameManager.Instance.PlatformXRange);
        newPos.y = transform.position.y + GameManager.Instance.PlatformYLevelStep * GameManager.Instance.NumberOfPlatformsLevels;
        return newPos;
    }
}
