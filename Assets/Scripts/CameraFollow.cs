using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float boundaryDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Right boundary
        if (target.transform.position.x - transform.position.x > boundaryDistance)
        {
            transform.position = new Vector3(target.transform.position.x - boundaryDistance, transform.position.y, transform.position.z);
        }

        // Left boundary
        if (target.transform.position.x - transform.position.x < boundaryDistance * -1)
        {
            transform.position = new Vector3(target.transform.position.x + boundaryDistance, transform.position.y, transform.position.z);
        }

        // Upper boundary
        if (target.transform.position.y - transform.position.y > boundaryDistance)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y - boundaryDistance, transform.position.z);
        }

        // Lower boundary
        if (target.transform.position.y - transform.position.y < boundaryDistance * -1)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y + boundaryDistance, transform.position.z);
        }
    }
}
