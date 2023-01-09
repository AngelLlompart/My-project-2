using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public float radi;
    private AudioSource _bombAudioSource;
    
    [SerializeField] private ParticleSystem hitParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _bombAudioSource = gameObject.GetComponent<AudioSource>();
        hitParticleSystem.startSize = radi;
        _bombAudioSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            hitParticleSystem.Play();
            Destroy(gameObject, 0.1f);
            DestroyEnemies();
        }
    }

    private void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            double distance = Mathf.Sqrt(Mathf.Pow(enemy.transform.position.x - transform.position.x, 2) + Mathf.Pow(enemy.transform.position.z - transform.position.z,2));
            if (distance < radi)
            {
                Destroy(enemy);
            }
        }
    }
}
