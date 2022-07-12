using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlatformGenerator.Instance.AddPlatform();
        Destroy(gameObject);
    }
}
