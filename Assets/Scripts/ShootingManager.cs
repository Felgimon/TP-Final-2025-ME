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
            bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, -90f, 0); //Misma rotacion que el gunpoint solo que le cambio el y para que el metal del dardo apunte bien.
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero; //Lo reinicio antes de ponerle el addForce para que no se llegue a stackear de los addForces de antes
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange); //Problema con el el addforce, salen a cualquier lado.
        }
    }
}
