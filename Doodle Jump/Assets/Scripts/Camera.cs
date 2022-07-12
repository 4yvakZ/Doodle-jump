using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform doodleTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (doodleTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, doodleTransform.position.y, transform.position.z);
        }
    }
}
