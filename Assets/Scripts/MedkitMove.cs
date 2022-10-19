using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MedkitMove : MonoBehaviour
{
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var newY = startY + 0.5f*Mathf.Sin(Time.time * 1);
        transform.position = new Vector3(transform.position.x, newY,transform.position.z);
    }
}
