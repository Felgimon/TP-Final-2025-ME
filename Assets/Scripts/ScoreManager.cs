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
        if (Input.GetKeyUp(KeyCode.E))
        {
            addScore(1);
        }
        if (score  == maxScore)
        {
            score = 0;
        }
    }

    public void addScore(int points)
    {
        score += points;
    }
}
