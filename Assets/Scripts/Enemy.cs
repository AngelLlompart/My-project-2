using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Start()
    {
        Subscribe();
    }

    public void Subscribe()
    {
        BombExplode.onGrenadeExplosion += Die;
    }

    public void Die(float radi, Transform bombTransform)
    {
        Debug.Log("A");
        //double distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - bombTransform.transform.position.x, 2) + Mathf.Pow(transform.position.z - bombTransform.transform.position.z,2));
        double distance = Vector3.Magnitude(transform.position - bombTransform.transform.position);
        if (distance < radi)
        {
            Destroy(this.gameObject);
            BombExplode.onGrenadeExplosion -= Die;
        }
    }

    public virtual void Move()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
