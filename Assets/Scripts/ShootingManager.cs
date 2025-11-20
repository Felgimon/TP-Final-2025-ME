using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletOffSet = 1f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = transform.position + transform.forward * bulletOffSet;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed); //Problema con el el addforce, salen a cualquier lado.
        }
    }
}
