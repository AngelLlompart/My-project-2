using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    private GameManager _gameManager;

    private CoinSpawner _coinSpawner;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _coinSpawner = FindObjectOfType<CoinSpawner>();
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
        else if(collider.gameObject.CompareTag("Enemy"))
        {
            _coinSpawner.SpawnNewCoin();
            Destroy(gameObject);
        }
    }
}
