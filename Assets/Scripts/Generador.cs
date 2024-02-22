using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.75f;
    private bool fin = false;

    // Use this for initialization
    void Start() {
        //Suscribirse al notificador
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeHaMuerto(Notification notification) {
        fin = true;
    }

    void PersonajeEmpiezaACorrer(Notification notification) {
        Generar();
    }

    // Update is called once per frame
    void Update() {

    }

    void Generar() {
        if (!fin) {
            //if length = 3, the value will be 0, 1 or 2, with int
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            //with float, the value is enter tiempoMin and tiempoMax, both values too
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }
    }
}
