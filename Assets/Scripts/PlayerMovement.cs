using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private int moveSpeed = 4;
    [SerializeField] 
    private int fuerzaSalto = 4;
    private Rigidbody _playerRb;

    private bool _isGrounded = true;

    private int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 10;
            Debug.Log("You lost 10% of your hp");
            Debug.Log("Hp remaining: " + hp + "%");
            
            if (hp <= 0)
            {
                Debug.Log("YOU DIED");
                Destroy(gameObject);
               
                #if UNITY_EDITOR
                if(EditorApplication.isPlaying) 
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
                #endif
            }
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            
            hp -= 30;
            Debug.Log("You lost 30% of your hp");
            Debug.Log("Hp remaining: " + hp + "%");
            
            if(hp <= 0)
            {
                Debug.Log("YOU DIED");
                Destroy(gameObject);
           
                #if UNITY_EDITOR
                if(EditorApplication.isPlaying) 
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
                #endif
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRb = this.gameObject.GetComponent<Rigidbody>();
            //añadir fuerza al objeto
            _playerRb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            _isGrounded = false;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
        float h = Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
}
