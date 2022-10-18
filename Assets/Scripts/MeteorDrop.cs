using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeteorDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        //transform.LookAt(_player.transform);
        direction = _player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * 10 * Time.deltaTime;
        transform.Translate(direction * Time.deltaTime * 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
