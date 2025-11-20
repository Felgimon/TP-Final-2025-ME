using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyList;
    [SerializeField] private float appearanceTime;
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
            if (!EnemyList[randomNumber].activeSelf) //Si no esta activo lo activo, y dejo en cero el tiempo de espera, sino se hace devuelta pq el elapsed time no se reinicia
            {
                EnemyList[randomNumber].SetActive(true);//Busco uno cualquiera de la lista y lo activo
                elapsed = 0;
            } 
            Debug.Log("Enemigo activado");
        }
    }
}
