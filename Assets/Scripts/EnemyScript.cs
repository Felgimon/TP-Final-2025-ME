using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManagerScript;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private float movingDistance;

    void Start()
    {
        startingPosition = transform.position;
    }

    private void OnEnable() //Cuando se activa el enemigo sube 
    {
        MoveEnemy();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Dart")
        {
            scoreManagerScript.addScore(1); // QUe el score se multiple por un numero que arranque en 5 y que vaya decreciendo en el paso del tiempo hasta que el tiempo llegue a cero.
            MoveEnemy(); // Baja
        }
    }

    private void MoveEnemy() //Llamada cuando aparece y cuando le pegas el disparo
    {
        Vector3 pos = transform.position;
        if (transform.position.y == startingPosition.y)
        {
           pos.y -= movingDistance;  //Si esta arriba que baje a su posicion inicial
           gameObject.SetActive(false);
        }
        else
        {
            pos.y += movingDistance; //Cuando esta en el subsuelo sube para arriba para que el jugador le dispare
        }
        transform.position = pos;
    }

    void Update()
    {
        
    }
}
