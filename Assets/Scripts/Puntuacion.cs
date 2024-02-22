using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

    public int puntacion = 0;
    public TextMesh marcador;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncremetarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        ActualizarMarcador();
    }

    void PersonajeHaMuerto (Notification notificacion) {
        var puntuacionMaximaAlmacenada = EstadoJuego.estadoJuego.puntuacionMaxima;
        if (puntacion > puntuacionMaximaAlmacenada) {            
            EstadoJuego.estadoJuego.puntuacionMaxima = puntacion;
            EstadoJuego.estadoJuego.Guardar();
        }
    }

    void IncremetarPuntos(Notification notificacion) {
        int puntosAIncrementar = (int)notificacion.data;
        puntacion += puntosAIncrementar;
        ActualizarMarcador();
    }

    void ActualizarMarcador() {
        marcador.text = puntacion.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
