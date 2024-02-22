using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

    public  GameObject camaraGameOver;
    public AudioClip clipSonidoGameOver;

	// Use this for initialization
	void Start () {
        //Registrarse como observardor
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

    void PersonajeHaMuerto(Notification notificacion) {
        //Obtener el componente audio el gameObject
        AudioSource audio = GetComponent<AudioSource>();
        //Detner la música
        audio.Stop();
        //Asignar el nuevo clip de audio, hacer que no esté en loop, reproducirlo
        audio.clip = clipSonidoGameOver;        
        audio.loop = false;
        audio.Play();   
        //Activar la cámara con sus componentes
        camaraGameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
