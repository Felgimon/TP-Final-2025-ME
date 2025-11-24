using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private ScoreManager scoreManagerScript;
    private Quaternion startingRotation;
    public GameObject lastEnemyKilled; //Se va a encargar de que no puedas quedarte siempre matando al mismo objetivo.
    [SerializeField] private float enemyLifeTime = 10;

    void Start()
    {
        startingRotation = transform.rotation;
        scoreManagerScript = GameObject.Find("ScoreManagerCanvas").GetComponent<ScoreManager>();
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
            CancelInvoke("Dead"); //Cancelo el invoke pendiente de cuando se activó.
            Dead(); //Con el sistema de 5 segundos de lifeTime se rompe. Creo que es porque el invoke no se cancela. Deberia cancelarse si es que le disparan antes. Quiza con un bool pero no tendria que ser con invoke.
        }
    }

    private void MoveEnemy() //Llamada cuando aparece y cuando le pegas el disparo
    {
        Quaternion rot = transform.rotation;
        Debug.Log("starting Rotation:" + startingRotation.x);
        Debug.Log("rotación actual:" + rot.x); //Quaternions del orto los odio.
        if (rot.x == startingRotation.x) //No se por qué hay variacion aunque están seteados con la misma variable. IMPORTANTE POR FIX
        {
            rot.x = 0;  //Si está acostado que se pare
        }
        else
        {
            rot = startingRotation;  //Si esta parado que se acueste
        }
        transform.rotation = rot;
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

    //TO DO : Hacer que la sumatoria de angulos suba y baje de a poco. O hacer animación en blende y re - import.
}
