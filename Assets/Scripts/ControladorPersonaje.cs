using UnityEngine;
using System.Collections;
public class ControladorPersonaje : MonoBehaviour {

	private float fuerzaSalto = 16f;
    public Transform comprobadorSuelo;
    public LayerMask mascaraSuelo;
    private float velocidad = 8.5f;

    private float comprobadorRadio = 0.07f;
    private bool enSuelo = true;
    private bool puedeDobleSalto = true;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool corriendo = false;    
    
    void Awake() {
        //Ahora es necesario instanciar el rigidbody2D (desde Unity 5.4.1p3)
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
    }

    void FixedUpdate() {
        if (corriendo) rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);        
        animator.SetFloat("VelX", rigidbody2D.velocity.x);        
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        animator.SetBool("isGrounded", enSuelo);
        if (enSuelo) puedeDobleSalto = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (corriendo && (puedeDobleSalto || enSuelo)) {                
                    GetComponent<AudioSource>().Play();
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
                    //rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
                    if (puedeDobleSalto && !enSuelo) puedeDobleSalto = false;
                
            } else {
                corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }            
        }        
    }
}