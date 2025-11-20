using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] int score = 0;
    [SerializeField] int maxScore = 10;
    void Start()
    {
        
    }

    void Update()
    {
        scoreTMP.text = score.ToString();
        if (score  == maxScore)
        {
            score = 0;
        }
    }

    public void addScore(int points)
    {
        score += points;
    }

    //To do: Funcion que cada vez que sumas puntos el color del puntaje se vuelva verde por
}
