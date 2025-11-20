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
            EnemyList[Random.Range(0, EnemyList.Count)].SetActive(true); //Busco uno cualquiera de la lista y lo activo
            Debug.Log("Enemigo activado");
            elapsed = 0;
        }
    }
}
