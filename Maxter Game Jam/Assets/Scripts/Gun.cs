using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunType
    {
        Player,
        Enemy
    }

    public GunType gunType;
    [SerializeField] private float maxReload;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    public float offset;

    private Player player;
    private float reload;
    private Vector3 difference;
    private float rotZ;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (gunType == GunType.Player && player.canMove)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        }

        else if (gunType == GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButton(0) || gunType == GunType.Enemy)
        {
            if (reload <= 0)
            {
                Shoot();
            }
        }

        if (reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        reload = maxReload;
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }


}
