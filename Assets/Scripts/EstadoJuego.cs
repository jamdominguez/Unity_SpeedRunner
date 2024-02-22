using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

    public static EstadoJuego estadoJuego;
    public int puntuacionMaxima = 0;
    private string rutaArchivo;

    //Se llama antes que Start, se usa para obtener referencias a otros componentes
    void Awake() {
        if (estadoJuego == null) {
            rutaArchivo = Application.persistentDataPath + "/datos.dat";
            Debug.Log("Path: " + rutaArchivo);
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        } else if (estadoJuego != this) {            
            Destroy(gameObject);
        }
    }

	// Use this for initialization, se hace uso de las variables y métodos de otros componentes
	void Start () {
        Cargar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Cargar() {
        if (File.Exists(rutaArchivo)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosParaGuarder datos = (DatosParaGuarder)bf.Deserialize(file);
            puntuacionMaxima = datos.puntuacionMaxima;
            file.Close();
        } else {
            puntuacionMaxima = 0;
        }
    }

    public void Guardar() {
        BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = new FileStream(rutaArchivo);
        FileStream file = File.Create(rutaArchivo);
        DatosParaGuarder datos = new DatosParaGuarder();
        datos.puntuacionMaxima = puntuacionMaxima;
        bf.Serialize(file, datos);  
        file.Close();
    }
}

[Serializable]
class DatosParaGuarder {
    public int puntuacionMaxima;
}
