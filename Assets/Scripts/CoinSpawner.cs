using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;

    private float xMin = 27.5f;
    private float xMax = 42.5f;
    private float zMin = -14.5f;
    private float zMax = 14.6f;
    private float yMin = 2.5f;
    private float yMax = 11f;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewCoin();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnNewCoin()
    {
        int xOffset = Random.Range(4, 7);
        int zOffset = Random.Range(4, 7);
        Vector3 offset = new Vector3(xOffset, 0, zOffset);
        
        float zOffset2 = Random.Range(zMin, zMax);
        float xOffset2 = Random.Range(xMin, xMax);
        float yOffset2 = Random.Range(yMin, yMax);
        Vector3 offset2 = new Vector3(xOffset2, yOffset2, zOffset2);
        //Instantiate(coinPrefab, transform.position + offset, Quaternion.identity);
        Instantiate(coinPrefab, offset2, Quaternion.identity);
    }
}
