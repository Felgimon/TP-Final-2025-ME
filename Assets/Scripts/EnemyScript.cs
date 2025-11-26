using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private ScoreManager scoreManagerScript;
    private Quaternion startingRotation;
    public GameObject lastEnemyKilled; //Se va a encargar de que no puedas quedarte siempre matando al mismo objetivo.
    private Animator zombieAnimator;
    [SerializeField] private float enemyLifeTime = 10;
    public bool isUp = false; //Variable local que corrobora si está acostado o no

    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        startingRotation = transform.rotation;
        scoreManagerScript = GameObject.Find("ScoreManagerCanvas").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (isUp)
        {
            zombieAnimator.SetBool("isUp", true);
            gameObject.GetComponent<Collider>().enabled = true;
            Invoke("Dead", enemyLifeTime); //5 segundos para que se acueste solo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Dart")
        {
            scoreManagerScript.addScore(1); 
            lastEnemyKilled = gameObject;
            CancelInvoke("Dead"); //Cancelo el invoke pendiente de cuando se activó.
            Dead(); 
        }
    }

    private void Dead()
    {
        Debug.Log("Zombie muerto");
        zombieAnimator.SetBool("isUp", false);
        isUp = false;
        gameObject.GetComponent<Collider>().enabled = false; //Para evitar que le peguen dos veces
    }


}
