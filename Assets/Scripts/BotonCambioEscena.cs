using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotonCambioEscena : MonoBehaviour {

    public string nuevaEscena = "GameScene";
    public bool quitApplication = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Cambia a la escena indicada, por defecto es "GameScene". Si el check Quit Application está marcado, cierra la aplicación
    void OnMouseDown() {        
        GetComponent<AudioSource>().Play();
        Invoke("LoadScene", GetComponent<AudioSource>().clip.length);
    }

    void LoadScene() {
        if (quitApplication) Application.Quit();
        else SceneManager.LoadScene(nuevaEscena);
    }
}
