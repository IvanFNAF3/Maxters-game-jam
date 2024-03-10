using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int maxEnemies;
    public bool spawnEnemies;

    private void Update()
    {
        if(enemies.Count >= maxEnemies)
        {
            spawnEnemies = false;
        }
        else
        {
            spawnEnemies = true;
        }
    }
}
