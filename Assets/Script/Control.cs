using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 Movimiento;
    float velocidad = 5f, disparo = 1000f;
    public Button up, down;
    bool pressedUP = false, pressedDOWN = false;
    public GameObject laser, Laser, UFOfire;
    public AudioSource laserSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       //Hace referencia al rigidbody del objeto que contiene el script (el UFO)
    }

    private void FixedUpdate()
    {
        if (pressedUP == true)              // Si el botón "UP" está presionado, la nave subirá
        {
            Vector2 moveInput = new Vector2(0, 5);
            Movimiento = moveInput.normalized * velocidad;
            rb.MovePosition(rb.position + Movimiento * Time.fixedDeltaTime);
            UFOfire.SetActive(true);
        }
        else { }
        if (pressedDOWN == true)            // Si el botón "DOWN" está presionado, la nave bajará
        {
            Vector2 moveInput = new Vector2(0, -5);
            Movimiento = moveInput.normalized * velocidad;
            rb.MovePosition(rb.position + Movimiento * Time.fixedDeltaTime);
            UFOfire.SetActive(false);
        }
        else { UFOfire.SetActive(true); }
    }

    public void onPressUP() { pressedUP = true; }       // Detecta si el botón "UP" está presionado
    public void onReleaseUp() { pressedUP = false; }

    public void onPressDown() { pressedDOWN = true; }       // Detecta si el botón "DOWN" está presionado
    public void onReleaseDown() { pressedDOWN = false; }


    public void Shoot()                // Genera y dispara el laser al momento de presionar el botón
    {
        laserSound.Play();
        laser = Instantiate(Laser, transform.position, Quaternion.identity);
        Rigidbody2D laserRB = laser.GetComponent<Rigidbody2D>();
        laserRB.AddForce(Vector2.right * disparo);
        Destroy(laser, 2f);
    }
}
