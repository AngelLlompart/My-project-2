using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private bool down = true;

    private int moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            if (transform.position.z <= -14)
            {
                down = false;
            }
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            if (transform.position.z >= -5)
            {
                down = true;
            }
        }
    }
}
