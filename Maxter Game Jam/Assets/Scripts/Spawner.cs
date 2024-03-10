using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject enemy;
    private GameManager gm;



    private void Start()
    {
        StartCoroutine(SpawnCD());
        gm = FindObjectOfType<GameManager>();
    }



    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(10);
        for (; ; )
        {
            if(gm.spawnEnemies)
            {
                Instantiate(enemy, SpawnPos.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(25);
        }
    }
}
