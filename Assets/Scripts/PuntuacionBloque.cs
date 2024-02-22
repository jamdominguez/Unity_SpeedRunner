using UnityEngine;
using System.Collections;

public class PuntuacionBloque : MonoBehaviour {

    private bool haColisionadoConElJugador = false;
    private int puntosPorTocaUnTronco = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        string nombreColliderReal = collision.contacts[0].collider.gameObject.name;
        bool colliderValido = ("PataInferiorDerechaB" == nombreColliderReal || "PataInferiorIzquierdaB" == nombreColliderReal);

        if ("Player" == collision.gameObject.tag && !haColisionadoConElJugador) {
            if (colliderValido) {
                NotificationCenter.DefaultCenter().PostNotification(this, "IncremetarPuntos", puntosPorTocaUnTronco);
                haColisionadoConElJugador = true;
            }
        }
    }
}
