using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int puntos = 0, primero = 0;      
    public Text puntosText;
    public bool checker = false;
    public SpriteRenderer UFO;
    public GameObject GameOver, PantallaGanadora;

    public static float timer = 10f;
    
    private void Update()
    {
        puntosText.text = puntos.ToString();

        if (checker == true)
        timer -= Time.deltaTime;


        if (timer <= 0f)                //Se encarga de restarle 5 puntos al pasar 10 segundos
        {
            timer = 10f;
            puntos -= 5;
        }

        if (primero > 0)                //Revisa si el juego está comenzando o si el puntaje está en cero por pérdida de puntos
        {
            checker = true;
        }

        if (puntos <= 0f && checker == true)        //Revisa si el jugador perdió
        {
            puntos = 0;
            primero = 0;
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        if (puntos >= 500)                      //Revisa si el jugador ganó
        {
            PantallaGanadora.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()          //Reinicia el juego
    {
        puntos = 0;
        primero = 0;
        timer = 10f;
        checker = false;
        GameOver.SetActive(false);
        PantallaGanadora.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
