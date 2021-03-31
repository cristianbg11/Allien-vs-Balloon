using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 Movimiento;
    float velocidad = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       //Hace referencia al rigidbody del objeto que contiene el script (el UFO)
    }
    private void Update()           
    {
        Vector2 moveInput = new Vector2(-5, 0);                     //Mueve el globos
        Movimiento = moveInput.normalized * velocidad;
        rb.MovePosition(rb.position + Movimiento * Time.fixedDeltaTime);
        Destroy(gameObject, 9f);                                //Destruye el globo después de que pasen 7 segundos (esto para que el rendimiento de juego sea óptimo)
    }
}
