using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private MineSpawner ms;

    private void Start()
    {
        ms = FindObjectOfType<MineSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().ChangeHealth(-45);
            ms.curMines--;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(45);
            ms.curMines--;
            Destroy(gameObject);
        }
    }
}
