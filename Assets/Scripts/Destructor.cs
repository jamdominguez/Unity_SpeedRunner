using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Este evento se lanza al chocar con otro Collider2D (other)
    public void OnTriggerEnter2D(Collider2D other) {
        if ("Player" == other.tag) {
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            GameObject personaje = GameObject.Find("Personaje");
            if(personaje != null) personaje.SetActive(false);
            //SceneManager.LoadScene("MainScene");
        } else {
            Destroy(other.gameObject);
        }
    }
}
