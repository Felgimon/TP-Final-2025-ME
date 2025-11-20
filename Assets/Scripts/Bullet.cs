using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bulletLifeTime = 10f;
    [SerializeField] private float timeElapsed = 0f;
    void Start()
    {
        
    }

    private void OnCollisionEnter()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Luego de bulletLifeTime segundos se desactiva
        if (gameObject.activeSelf)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= bulletLifeTime) 
            {
                gameObject.SetActive(false);
                timeElapsed = 0f;
            }
        }
    }
}
