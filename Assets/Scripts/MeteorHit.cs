using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MeteorHit : MonoBehaviour
{
    private AudioSource _meteorAudioSource;

    [SerializeField] private AudioClip hitFloorAudioClip;

    [SerializeField] private AudioClip hitPlayerAudioClip;

    [SerializeField] private ParticleSystem hitFloorParticleSystem;
    
    [SerializeField] private ParticleSystem hitPlayerParticleSystem;

    
    // Start is called before the first frame update
    void Start()
    {
        _meteorAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _meteorAudioSource.PlayOneShot(hitPlayerAudioClip, 2.0f);
            hitPlayerParticleSystem.Play();
        }
        else
        {
            _meteorAudioSource.PlayOneShot(hitFloorAudioClip, 2.0f);
            hitFloorParticleSystem.Play();
        }
        Destroy(gameObject, 1f);
    }
}
