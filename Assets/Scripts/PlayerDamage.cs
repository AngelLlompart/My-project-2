using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameManager _gameManager;

    private Level1Manager _level1;

   // [SerializeField] private ParticleSystem hitMeteorParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //_gameManager = FindObjectOfType<GameManager>();
        _level1 = FindObjectOfType<Level1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //_gameManager.Damage(10);
            _level1.Damage(10);
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
           // _gameManager.Damage(30);
           
            _level1.Damage(30);
            //hitMeteorParticleSystem.Play();
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            if (_level1.hp != 100)
            {
                Destroy(collision.gameObject);
            }
            _level1.Heal(50);
        }
    }

}
