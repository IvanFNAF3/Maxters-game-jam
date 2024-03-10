using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    public int maxMines;
    public GameObject mine;
    public int curMines;

    private void Start()
    {
        StartCoroutine(SpawnMine());
    }

    private IEnumerator SpawnMine()
    {
        for(; ; )
        {
            if (curMines < maxMines)
            {
                curMines++;
                Vector3 randPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
                Instantiate(mine, randPos, Quaternion.identity);
                yield return new WaitForSeconds(5);
            }
        }
    }
}
