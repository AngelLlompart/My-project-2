using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject meteorPrefab;

    private float timer = 0.0f;

    private float meteorSpawnFreq = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= meteorSpawnFreq)
        {
            timer = 0.0f;
            Instantiate(meteorPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(meteorPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(4);
        }
    }
}
