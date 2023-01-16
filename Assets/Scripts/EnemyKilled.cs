using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BombExplode.onGrenadeExplosion += Die;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die(float radi, Transform bombTransform)
    {
        double distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - bombTransform.transform.position.x, 2) + Mathf.Pow(transform.position.z - bombTransform.transform.position.z,2));
        if (distance < radi)
        {
            Destroy(this.gameObject);
            BombExplode.onGrenadeExplosion -= Die;
        }
    }
}
