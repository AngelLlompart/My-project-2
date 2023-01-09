using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    [SerializeField] private GameObject _bombSpawner;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject bombInst = Instantiate(bomb, _bombSpawner.transform.position, Quaternion.identity);
            Rigidbody bombRb = bombInst.GetComponent<Rigidbody>();
            bombRb.AddForce(transform.forward * 1000);
        }
    }
}
