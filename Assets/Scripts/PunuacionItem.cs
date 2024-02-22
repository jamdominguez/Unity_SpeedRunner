using UnityEngine;
using System.Collections;

public class PunuacionItem : MonoBehaviour {

    private int puntosPorTocaUnItem = 5;    

    //Si isTrigger está seleccionado el objeto collider no será rígido y permitirá ser traspasado

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if ("Player" == collider.tag) {
            //AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            NotificationCenter.DefaultCenter().PostNotification(this, "IncremetarPuntos", puntosPorTocaUnItem);
            //El audio está asociado al objeto, si lo destruyo nada más hacer play() se cortará el audio, incluso ni llegará a oirse.
            //Por ello opto por esconder el objeto muy lejos, detrás del fondo de la escena y espero que termine el audio para destruirlo.
            gameObject.transform.position = new Vector3(0, 0, 50);
            Invoke("EliminarItem", audio.clip.length);
            
        }        
    }

    void EliminarItem() {
        Destroy(gameObject);
    }
}
