using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 posIni;

    private Vector3 posFinal;
    // Start is called before the first frame update
    void Start()
    {
        posIni = transform.position;
        posFinal = transform.position + new Vector3(0,0,-6);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == posIni && transform.position != posFinal)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        else if()
        { 
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
    }
}
