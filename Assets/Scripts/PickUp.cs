using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _gameManager.IncrementarMonedas();
            Destroy(gameObject);
        }
    }
}
