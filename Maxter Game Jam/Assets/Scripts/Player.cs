using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float maxSpeed;
    public int health;
    public float cooldown;

    private float healthCd;
    [SerializeField] private Text hpText;
    [SerializeField] private Slider sl;
    [SerializeField] private Transform gun;
    [SerializeField] private SpriteRenderer[] bodyParts;
    

    private float speed;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isRight = true;
    void Start()
    {
        health = maxHealth;
        speed = maxSpeed;

        sl.maxValue = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(MinusHp());
    }

    private void FixedUpdate()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = moveInput * speed;
    }

    private void Update()
    {
        if (isRight && moveInput.x < 0)
        {
            Rotate();
        }
        else if (!isRight && moveInput.x > 0)
        {
            Rotate();
        }

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(healthCd > 0)
        {
            healthCd -= Time.deltaTime;
        }
    }

    void Rotate()
    {
        isRight = !isRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        Vector3 gunScaler = gun.transform.localScale;
        gunScaler.x *= -1;
        gun.transform.localScale = gunScaler;
        
    }

    public void ChangeHealth(int value)
    {
        if(value > 0 && healthCd <= 0)
        {
            health += value;
            StartCoroutine(BloodEffect());
            healthCd = cooldown;
        }
        else if(value < 0)
        {
            health += value;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            //Переход на след. уроввень!
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        sl.value = health;
        hpText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    private IEnumerator MinusHp()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(0.5f);
            ChangeHealth(-1);
        }
    }

    private IEnumerator BloodEffect()
    {
        //print("HEAL");
        for (float r = 0f; r < 1f; r += 0.1f)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].color = new Color(r, 1, r, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}