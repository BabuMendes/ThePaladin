using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragao : MonoBehaviour
{
    public GameObject Jogador;
    public NavMeshAgent Reptil;
    private float distProcurar;
    public int hp = 2;
    public bool procurar;
    public float distancePerseguir;
    public float distanciaAtacar;
    private Rigidbody Corpo;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //Jogador = GameObject.FindGameObjectWithTag("Player");
        Reptil = GetComponent<NavMeshAgent>();
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
            Mago.SetDestination(Jogador.transform.position);
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
                Reptil.isStopped = true;
                Reptil.velocity = Vector3.zero;
                animator.SetBool("Correndo", false);
                animator.SetBool("Atacando", true);
            }
        }
        else
        {
            Reptil.isStopped = true;
            Reptil.velocity = Vector3.zero;
            animator.SetBool("Correndo", false);
            animator.SetBool("Atacando", false);
        }



        //Atacar();


    }

    void Mover()
    {
        Reptil.SetDestination(Jogador.transform.position);
        animator.SetBool("Correndo", true);
        Reptil.isStopped = false;
        //Esqueleto.velocity = Vector3.zero;
    }


    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Espada")
        {
            TomeiDano();
        }
    }

    public void TomeiDano()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Atacar()
    {

    }

}
