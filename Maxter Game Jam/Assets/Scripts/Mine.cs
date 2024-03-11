using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private MineSpawner ms;
    public GameObject mineEffect;
    public int damage;

    private void Start()
    {
        ms = FindObjectOfType<MineSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().ChangeHealth(-damage);
            DestroyMine();
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            DestroyMine();
        }
    }

    public void DestroyMine()
    {
        ms.curMines--;
        Instantiate(mineEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
