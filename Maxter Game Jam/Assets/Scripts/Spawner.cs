using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;


    public GameObject enemy;



    private void Start()
    {
        StartCoroutine(SpawnCD());
    }



    IEnumerator SpawnCD()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(10f);
            Instantiate(enemy, SpawnPos.position, Quaternion.identity);
        }
    }
}
