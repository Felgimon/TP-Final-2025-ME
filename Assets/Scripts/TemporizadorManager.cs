using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemporizadorManager : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private float timeRemaining;// Tiempo límite en segundos
    [SerializeField] private TextMeshProUGUI tempTMP;
    void Start()
    {
        timeRemaining = timeLimit;
    }
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        tempTMP.text = Mathf.Round(timeRemaining).ToString();
        if (timeRemaining  <= 0)
        {
            timeRemaining = timeLimit;
        }
    }
}
