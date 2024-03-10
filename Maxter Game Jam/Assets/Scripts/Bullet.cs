using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool enemyBullet;
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask mask;
    public GameObject bulletEffect;

    private void Awake()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, mask);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy") && !enemyBullet)
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestroyBullet();
            }
            if (hitInfo.collider.CompareTag("Player") && enemyBullet)
            {
                hitInfo.collider.GetComponent<Player>().ChangeHealth(damage);
                DestroyBullet();
            }
        }
    }

    public void DestroyBullet()
    {
        Instantiate(bulletEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
