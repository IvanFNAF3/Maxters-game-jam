using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int maxEnemies;
    public bool spawnEnemies;
    public int maxTime;
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
