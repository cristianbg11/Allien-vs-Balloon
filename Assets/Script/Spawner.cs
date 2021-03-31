using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] globos;
    public float respawnTime = 2f;
    private Vector2 screenBounds;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));      //Determina el tamaño de la cámara (las dimensiones del juego)
        StartCoroutine(Globos());        
    }

    private void spawnGlobo()
    {
        int globoAleatorio = Random.Range(0, globos.Length);                                                    //Elige un globo aleatorio y luego lo generarlo
        GameObject a = Instantiate(globos[globoAleatorio]) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    
    IEnumerator Globos()                                    //Llama a la función que genera los globos, cada cierto tiempo
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnGlobo();
        }
    }
}
