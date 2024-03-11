using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int balls;
    public int maxEnemies;
    public bool spawnEnemies;
    public int maxTime;
    public GameObject monster;
    [SerializeField] private AudioSource monsterSpawnMp3;
    [SerializeField] private Text counterText;
    private Player player;

    private int time;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        time = maxTime;
        StartCoroutine(CounterCoroutine());
    }

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

    public void CheckMonster()
    {
        balls--;
        if(balls <= 0)
        {
            SpawnMonster(true);
        }
    }

    public void SpawnMonster(bool isSpawn)
    {
        monsterSpawnMp3.Play();
        monster.SetActive(isSpawn);
    }

    private IEnumerator CounterCoroutine()
    {
        for(; ; )
        {
            time--;
            counterText.text = "Осталось: " + time;
            if(time <= 0)
            {
                player.StartDeath();
                yield return new WaitForSeconds(2);
                player.GameOver();
                yield return new WaitForSeconds(1);
                player.EndDeath();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
