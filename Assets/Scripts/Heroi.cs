using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heroi : MonoBehaviour
{


    private Vector3 Destino;
    public GameObject MeuAtaque;
    private Animator ControlAnim;
    [SerializeField]private GerenciadorMenu GM;
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
        float velocidadeZ = Input.GetAxis("Vertical") * 7;
        float velocidadeX = Input.GetAxis("Horizontal2") * 5;
        Vector3 velocidadeCorrigida = velocidadeX * transform.right + velocidadeZ * transform.forward;

        Corpo.velocity = new Vector3(velocidadeCorrigida.x, Corpo.velocity.y, velocidadeCorrigida.z);
        if (Corpo.velocity.magnitude > 1 && noChao == true)
        {
            if( velocidadeX == 0)
            {
                ControlAnim.SetBool("Andar", true);
                ControlAnim.SetBool("AndarL", false);
                ControlAnim.SetBool("AndarR", false);
            }
            else if (velocidadeX > 0)
            {
                ControlAnim.SetBool("AndarR", true);
                ControlAnim.SetBool("Andar", false);
                ControlAnim.SetBool("AndarL", false);
            }
            else
            {
                ControlAnim.SetBool("AndarL", true);
                ControlAnim.SetBool("Andar", false);
                ControlAnim.SetBool("AndarR", false);
            }
        }
        else
        {
            ControlAnim.SetBool("Andar", false);
            ControlAnim.SetBool("AndarL", false);
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
                ControlAnim.SetTrigger("Pular");
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
        if(vivo == true)
        {
            vivo = false;
            ControlAnim.SetTrigger("Morreu");
        }
    }
    public void Morreu()
    {

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
        if (colidiu.CompareTag("Saida"))
        {
            GM.Greetings();
        }
    }
    private void OnTriggerStay(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Chao")
        {
            qtdPulos = 1;
            noChao = true;
        }
    }
    public void AtivarAtk()
    {
        MeuAtaque.SetActive(true);
    }
    public void DesativarAtk()
    {
        MeuAtaque.SetActive(false);
    }
    public void Pulei()
    {
        Corpo.AddForce(Vector3.up * 10000);
    }
}
