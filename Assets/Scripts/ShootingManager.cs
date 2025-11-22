using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletOffSet = 1f;
    [SerializeField] private Transform cameraTr;
    [SerializeField] private float rayDistance;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Requesteo bullet
            GameObject bullet = BulletPool.Instance.RequestBullet();
            //Configuraciones pq el rb es malardo, deberia de haberlo hecho con velocity, maldito anunciado.
            bullet.transform.position = transform.position + transform.forward * bulletOffSet;
            bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, -90f, 0); //Misma rotacion que el gunpoint solo que le cambio el "y" para que el metal del dardo apunte bien.
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero; //Lo reinicio antes de ponerle el addForce para que no se llegue a stackear de los addForces de antes
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange); //Problema con el el addforce, salen a cualquier lado.
        }
        RaycastHit hit;
        if (Physics.Raycast(cameraTr.position, cameraTr.forward, out hit, rayDistance)) {
            Debug.Log("colision raycast:" + hit.point);
        }

        Gizmos.color = Color.yellow;
        Debug.DrawRay(cameraTr.position, cameraTr.forward * rayDistance, Gizmos.color);
    }
}
