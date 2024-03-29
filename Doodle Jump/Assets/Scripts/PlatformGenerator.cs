using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public static PlatformGenerator Instance { get; set; }

    [SerializeField] private GameObject initialPlatform;
    [SerializeField] private List<GameObject> platformType;

    [SerializeField] private int numberOfPlatformsLevels = 10;
    [SerializeField] private float platformXRange = 2f;
    [SerializeField] private float minimalPlatformYSpan = 1f;
    [SerializeField] private float maximalPlatformYSpan = 2.5f;

    List<GameObject> platforms = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        platforms.Add(initialPlatform);
        GeneratePlatforms(numberOfPlatformsLevels);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlatforms(int numberOfPlatforms)
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            CreatePlatform();
        }
    }

    public void CreatePlatform()
    {
        var randomValue = Random.Range(0f, 10f);
        int typeIndex = 2;
        if (randomValue <= 5)
        {
            typeIndex = 0;
        }
        else if (randomValue <= 8)
        {
            typeIndex = 1;
        }
        var newPlatform = Instantiate(platformType[typeIndex], GeneratePlatformPos(platforms.Count - 1), platformType[typeIndex].transform.rotation);
        platforms.Add(newPlatform);
    }
    Vector3 GeneratePlatformPos(int refPlatformIndex)
    {
        Vector3 platformPos = new Vector3();
        platformPos.x = Random.Range(-platformXRange, platformXRange);
        var lastPlatformY = platforms[refPlatformIndex].transform.position.y;
        platformPos.y = Random.Range(lastPlatformY + minimalPlatformYSpan, lastPlatformY + maximalPlatformYSpan);
        return platformPos;
    }

    public void AddPlatform()
    {
        platforms.RemoveAt(0);
        CreatePlatform();
    }
    
}
