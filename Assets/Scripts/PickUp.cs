using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    private AudioSource _playerAudioSource;
    //private GameManager _gameManager;
    //private CoinSpawner _coinSpawner;
    
    //public delegate void IncrementarMonedas();
    public static event Action incrementarMonedas;
    public static event Action spawnCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        //_gameManager = FindObjectOfType<GameManager>();
        //_coinSpawner = FindObjectOfType<CoinSpawner>();
        _playerAudioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //_gameManager.IncrementarMonedas();
            
            //Play sound effect collect coin
            _playerAudioSource.Play();
            incrementarMonedas();
            Destroy(gameObject);
        }
        else if(collider.gameObject.CompareTag("Enemy"))
        {
            spawnCoin();
            Destroy(gameObject);
        }
    }
}
