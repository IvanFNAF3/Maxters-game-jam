using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int health;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ChangeHP(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Remove from list
            gm.CheckMonster();
            Destroy(gameObject);
        }
    }

}
