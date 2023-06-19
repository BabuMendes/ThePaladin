using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroi : MonoBehaviour
{


    private Vector3 Destino;
    public GameObject MeuAtaque;
    private Animator ControlAnim;
    private GerenciadorDeObjetos Inventario;

    //Movimento
    private Rigidbody Corpo;

    public float hp = 1;
    public bool vivo = true;


    //Variaveis
    public bool noChao = true;
    public int qtdPulos = 1;

    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody>();
        ControlAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ControleAtaque();
        Mover();
        Pular();
        Pegar();
    }

    void Mover()
    {
        float velocidadeZ = Input.GetAxis("Vertical") * 6;
        float velocidadeX = 0;
        Vector3 velocidadeCorrigida = velocidadeX * transform.right + velocidadeZ * transform.forward;

        Corpo.velocity = new Vector3(velocidadeCorrigida.x, Corpo.velocity.y, velocidadeCorrigida.z);

        if (noChao == true)
        {
            if (Corpo.velocity.magnitude > 1)
            {
                ControlAnim.SetBool("Andar", true);
            }
            else
            {
                ControlAnim.SetBool("Andar", false);
            }
        }
        Girar();
    }

    void Girar()
    {
        float GiroY = Input.GetAxis("Horizontal") * 100 * Time.deltaTime;
        transform.Rotate(Vector3.up * GiroY);

    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (qtdPulos >0)
            {
                ControlAnim.SetBool("Pular", true);
                Corpo.AddForce(Vector3.up * 1000);
                qtdPulos--;
                noChao = false;
            }

        }
        else
        {
            ControlAnim.SetBool("Pular", false);
        }
    }

    void Pegar()
    {
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            ControlAnim.SetTrigger("Pegar");
        }
    }

    void ControleAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
        {
            ControlAnim.SetTrigger("Ataque");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            ControlAnim.SetTrigger("Disparo");
        }
    }



    public void Morrer()
    {
        vivo = false;
        ControlAnim.SetBool("Morreu", true);
    }
    
    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Chao")
        {
            qtdPulos = 1;
            noChao = true;
        }
        if (colidiu.gameObject.tag == "Espinho")
        {
            Morrer();
        }
    }
}
