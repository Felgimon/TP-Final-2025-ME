using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletOffSet = 0.5f;
    [SerializeField] Transform cameraTr;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = cameraTr.position + cameraTr.forward * bulletOffSet;
            bullet.GetComponent<Rigidbody>().AddForce(cameraTr.forward * bulletSpeed); //Problema con el el addforce, salen a cualquier lado.
        }
    }
}
