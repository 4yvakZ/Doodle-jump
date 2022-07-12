using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    [SerializeField] private int numberOfPlatformsLevels = 10;
    [SerializeField] private float platformXRange = 2f;
    [SerializeField] private float platformYRange = 1f;
    [SerializeField] private float platformYLevelStep = 3f;
    [SerializeField] private float platformFirstLevelY = -2f;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatforms(numberOfPlatformsLevels);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePlatforms(int numberOfPlatformsLevels)
    {
        for (int i = 0; i < numberOfPlatformsLevels; i++)
        {
            int numberOfPlatformsOnLevel = Random.Range(1, 3);
            Debug.Log("Level: " + i + " Platforms: " + numberOfPlatformsOnLevel);
            for (int j = 0; j < numberOfPlatformsOnLevel; j++)
            {
                Instantiate(platform, GeneratePlatformPos(i), platform.transform.rotation);
            }
        }
    }

    Vector3 GeneratePlatformPos(int level)
    {
        Vector3 platformPos = new Vector3();
        platformPos.x = Random.Range(-platformXRange, platformXRange);
        platformPos.y = Random.Range(platformYLevelStep * level + platformFirstLevelY - platformYRange, platformYLevelStep * level + platformFirstLevelY + platformYRange);
        return platformPos;
    }
}
