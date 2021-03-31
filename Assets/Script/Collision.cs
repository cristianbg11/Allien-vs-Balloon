using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] public ParticleSystem ballonBoom;
    public AudioSource balloonPop;

    void OnCollisionEnter2D(Collision2D impacto)
    {
        if (impacto.gameObject.tag == "GloboRojo")      //Revisa si el objeto con el que colisiona es el globo rojo
        {
            balloonPop.Play();

            ScoreManager.puntos += 1;
            ScoreManager.primero += 1;
            Destroy(impacto.gameObject);    //Destruye el objeto con el que colisiona
        }

        if (impacto.gameObject.tag == "GloboAzul")      //Revisa si el objeto con el que colisiona es el globo rojo
        {
            balloonPop.Play();

            ScoreManager.puntos += 10;
            ScoreManager.primero += 1;
            Destroy(impacto.gameObject);    //Destruye el objeto con el que colisiona
        }
        Destroy(gameObject);        // Destruye el laser
    }
}
