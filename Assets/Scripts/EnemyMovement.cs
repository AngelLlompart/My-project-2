using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    private int movespeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = _player.transform.position - transform.position;
        transform.LookAt(_player.transform);
        //transform.Translate(direction * 0.5f * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
        
    }
}
