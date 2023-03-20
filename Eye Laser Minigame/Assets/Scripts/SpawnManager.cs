using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startSpawning());
    }

    IEnumerator startSpawning()
    {
        yield return new WaitForSeconds(4);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemies[0], spawnPoints[i].position, Quaternion.identity);
        }
        StartCoroutine(startSpawning());
    }
}
