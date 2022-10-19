using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private int moveSpeed = 4;
    [SerializeField] 
    private int fuerzaSalto = 4;
    private Rigidbody _playerRb;

    private bool _isGrounded = true;

    
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

        if (collision.gameObject.CompareTag("Speed"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpeedUp());
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

    IEnumerator SpeedUp()
    {
        moveSpeed += 4;
        yield return new WaitForSecondsRealtime(2);
        moveSpeed -= 4;
    }
}
