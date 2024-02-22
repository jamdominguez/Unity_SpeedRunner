using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    public bool iniciarEnMovimiento = false;
    public float velocidad = 0f;
    private bool enMovimiento = false;
    private float tiempoInicio = 0f;

	// Use this for initialization
	void Start () {
        //Suscribirse al notificador
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        if (iniciarEnMovimiento) {
            PersonajeEmpiezaACorrer();
        }
    }

    void PersonajeHaMuerto() {
        enMovimiento = false;
    }

    void PersonajeEmpiezaACorrer() {
        enMovimiento = true;
        tiempoInicio = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (enMovimiento) GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
	}
}
