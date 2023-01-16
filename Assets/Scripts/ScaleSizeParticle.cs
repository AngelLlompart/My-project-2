using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSizeParticle : MonoBehaviour
{
    private BombExplode _bombExplode;

    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        _bombExplode = FindObjectOfType<BombExplode>();
        scale = _bombExplode.radi;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnWillRenderObject() {
        if( transform.lossyScale.x < 0 ) {
            transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y * scale, transform.localScale.z * scale);
        }
    }
    
}
