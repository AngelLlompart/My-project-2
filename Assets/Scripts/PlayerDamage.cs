using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(10);
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            Damage(30);
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            if (hp != 100)
            {
                if (hp + 50 >= 100)
                {
                    hp = 100;
                }
                else
                {
                    hp += 50;
                }
                Debug.Log("+50 HP, Current HP: " + hp);
                Destroy(collision.gameObject);
            }
        }
    }

    void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        Debug.Log("You lost " + dmgAmount +"% of your hp");
        Debug.Log("Hp remaining: " + hp + "%");
        if (hp <= 0)
        {
            Debug.Log("YOU DIED");
            Destroy(gameObject);

            #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            #endif
        }
    }
}
