using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _gameManager.Damage(10);
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            _gameManager.Damage(30);
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            if (_gameManager.hp != 100)
            {
                Destroy(collision.gameObject);
            }
            _gameManager.Heal(50);
        }
    }

}
