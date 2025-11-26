using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyList;
    [SerializeField] private float appearanceTime;
    [SerializeField] private EnemyScript enemyScript;
    private float elapsed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > appearanceTime) //cada appearanceTime segundos 
        {
            int randomNumber = Random.Range(0, EnemyList.Count);
            if (!EnemyList[randomNumber].GetComponent<EnemyScript>().isUp && EnemyList[randomNumber] != enemyScript.lastEnemyKilled) //Si no esta activo lo activo, y dejo en cero el tiempo de espera, sino se hace devuelta pq el elapsed time no se reinicia
            {
                EnemyList[randomNumber].GetComponent<EnemyScript>().isUp = true; //Seteo que está acostado
                elapsed = 0;
            } 
            //Debug.Log("Enemigo activado");
        }
    }
}
