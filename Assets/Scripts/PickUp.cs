using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
  
    private CoinSpawner _coinSpawner;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
            Debug.Log(10 * _coinSpawner.coins + "€");
            if (_coinSpawner.coins == _coinSpawner.maxCoins)
            {
                Debug.Log("GAME OVER");
                Destroy(GameObject.FindObjectOfType<PlayerMovement>());
            }
            _coinSpawner.SpawnNewCoin();
        }
    }
}
