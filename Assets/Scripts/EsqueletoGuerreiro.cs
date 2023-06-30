using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EsqueletoGuerreiro : MonoBehaviour
{
    public GameObject Jogador;
    public NavMeshAgent Esqueleto;
    private float distProcurar;
    public int hp = 2;
    public bool procurar;
    public float distancePerseguir;
    public float distanciaAtacar;
    private Rigidbody Corpo;

    Animator animator;

    public GameObject MeuAtaque;
    private bool podemover = true;
    private bool morto = false;


    // Start is called before the first frame update
    void Start()
    {
        //Jogador = GameObject.FindGameObjectWithTag("Player");
        Esqueleto = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("KJIHO");
        Time.timeScale = 1;
        //float dist = Vector3.Distance(Jogador.transform.position, transform.position);
        //bool procurar = (dist < distProcurar);
        /*
        transform.LookAt(Jogador.transform);

        if (procurar == true)
        {
            transform.LookAt(Jogador.transform.position);
            Esqueleto.SetDestination(Jogador.transform.position);
        }

        if (procurar == false)
        {
            transform.LookAt(transform.position);
        }*/
        float Distance = Vector3.Distance(transform.position, Jogador.transform.position);
        if (Distance <= distancePerseguir)
        {
            if (Distance >= distanciaAtacar)
            {
                Mover();
                animator.SetBool("Atacando", false);
            }
            else
            {
                Esqueleto.isStopped = true;
                Esqueleto.velocity = Vector3.zero;
                animator.SetBool("Correndo", false);
                animator.SetBool("Atacando", true);
            }
        }
        else
        {
            Esqueleto.isStopped = true;
            Esqueleto.velocity = Vector3.zero;
            animator.SetBool("Correndo", false);
            animator.SetBool("Atacando", false);
        }



        //Atacar();


    }

    void Mover()
    {
        if (podemover == true)
        {
            Esqueleto.SetDestination(Jogador.transform.position);
            animator.SetBool("Correndo", true);
            Esqueleto.isStopped = false;
            //Esqueleto.velocity = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider colidiu)
    {
        if (morto == false)
        {
            if (colidiu.gameObject.tag == "Espada")
            {
                TomeiDano();
            }
        }
    }

    public void TomeiDano()
    {
        animator.SetTrigger("morto");
        podemover = false;
        morto = true;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
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

}
