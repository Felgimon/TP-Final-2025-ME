using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManagerScript;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private float movingDistance;
    public GameObject lastEnemyKilled; //Se va a encargar de que no puedas quedarte siempre matando al mismo objetivo.
    [SerializeField] private float enemyLifeTime = 10;

    void Start()
    {
        startingPosition = transform.position;
    }

    private void OnEnable() //Cuando se activa el enemigo sube 
    {
        gameObject.GetComponent<Collider>().enabled = true;
        MoveEnemy();
        Invoke("Dead", enemyLifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Dart")
        {
            scoreManagerScript.addScore(1); // Que el score se multiple por un numero que arranque en 5 y que vaya decreciendo en el paso del tiempo hasta que el tiempo llegue a cero.
            lastEnemyKilled = gameObject;
            Dead(); //Con el sistema de 5 segundos de lifeTime se rompe. Creo que es porque el invoke no se cancela. Deberia cancelarse si es que le disparan antes. Quiza con un bool pero no tendria que ser con invoke.
        }
    }

    private void MoveEnemy() //Llamada cuando aparece y cuando le pegas el disparo
    {
        Vector3 pos = transform.position;
        if (pos.y == startingPosition.y)
        {
           pos.y -= movingDistance;  //Cuando esta en el subsuelo sube para arriba para que el jugador le dispare
        }
        else
        {
            pos.y += movingDistance;  //Si esta arriba que baje a su posicion inicial
        }
        transform.position = pos;
    }

    void Update()
    {
        
    }

    private void Dead()
    {
        MoveEnemy();
        gameObject.SetActive(false);
        gameObject.GetComponent<Collider>().enabled = false; //Para evitar que le peguen dos veces
    }
}
