using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private float timeRemaining;// Tiempo límite en segundos
    [SerializeField] private TextMeshProUGUI tempTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI resultTMP;
    [SerializeField] private GameObject mira;
    [SerializeField] int score = 0;
    [SerializeField] int maxScore = 10;
    [SerializeField] float changeColorDuration = 0.25f;
    private bool isChangingColor = false;
    private float t = 0f;
    private int phase = 0; 
    private Color baseColor = Color.white;
    private Color highlightColor = new Color(0f, 1f, 0f);

    //TO DO: // Que el score se multiple por un numero que arranque en 5 y que vaya decreciendo en el paso del tiempo hasta que el tiempo llegue a cero.
    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        scoreTMP.text = score.ToString() + "/" + maxScore.ToString();
        if (score  == maxScore)
        {
            StartCoroutine(ResultOfGame("GANASTE", Color.green));
        }
        changeTextColor();

        timeRemaining -= Time.deltaTime;
        tempTMP.text = Mathf.Round(timeRemaining).ToString();
        if (timeRemaining <= 0)
        {
            StartCoroutine(ResultOfGame("PERDISTE", Color.red));
        }
    }

    IEnumerator ResultOfGame(string textoResult, Color color)
    {
        mira.SetActive(false);
        Time.timeScale = 0f;
        resultTMP.text = textoResult;
        resultTMP.color = color;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void addScore(int points)
    {
        score += points;
        isChangingColor = true;
        t = 0f;
        phase = 0;
    }

    private void changeTextColor()
    {
        if (isChangingColor) //Si sumo score hago que se vuelva verde de a poco y pueda volver a blanco de a poco
        {
            t += Time.deltaTime / changeColorDuration;
            if (phase == 0) // ir a verde
            {
                scoreTMP.color = Color.Lerp(baseColor, highlightColor, t);

                if (t >= 1f)
                {
                    phase = 1;
                    t = 0f;
                }
            }
            else if (phase == 1) // volver a blanco
            {
                scoreTMP.color = Color.Lerp(highlightColor, baseColor, t);

                if (t >= 1f)
                {
                    // Termina la animación
                    isChangingColor = false;
                    phase = 0;
                    t = 0f;
                }
            }

        }
    }

    //To do: Funcion que cada vez que sumas puntos el color del puntaje se vuelva verde por
}
