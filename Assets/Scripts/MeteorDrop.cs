using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeteorDrop : MonoBehaviour
{
    private GameObject _player;
    private Vector3 direction;
    private Rigidbody _meteorRigidBody;
    [SerializeField]
    private float movespeed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        //transform.LookAt(_player.transform);
        _meteorRigidBody = gameObject.GetComponent<Rigidbody>();
        direction = _player.transform.position - transform.position;
        _meteorRigidBody.velocity = direction * movespeed;
        //Debug.Log("El meteorit " + gameObject.name + " surt amb una velocitat de " + _meteorRigidBody.velocity + " " + _meteorRigidBody.velocity.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * 10 * Time.deltaTime;
        
        //transform.Translate(direction * Time.deltaTime * movespeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
