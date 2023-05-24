using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroi : MonoBehaviour
{


    private Vector3 Destino;
    public GameObject MeuAtaque;
    private Animator ControlAnim;

    //Movimento
    private Rigidbody Corpo;



    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody>();
        ControlAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
    }

    void Mover()
    {
        float velocidadeZ = Input.GetAxis("Vertical") * 3;
        float velocidadeX = 0;
        Vector3 velocidadeCorrigida = velocidadeX * transform.right + velocidadeZ * transform.forward;

        Corpo.velocity = new Vector3(velocidadeCorrigida.x, Corpo.velocity.y, velocidadeCorrigida.z);
        
        if (Corpo.velocity.magnitude > 1)
        {
            ControlAnim.SetBool("Andar", true);
        }
        else
        {
            ControlAnim.SetBool("Andar", false);
        }
        Girar();
    }

    void Girar()
    {
        float GiroY = Input.GetAxisRaw("Joy2") * 1000 * Time.deltaTime;
        transform.Rotate(Vector3.up * GiroY);

    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Corpo.AddForce(Vector3.up * 250);
            ControlAnim.SetBool("Pular", true);
        }
        else
        {
            ControlAnim.SetBool("Pular", false);
        }
    }
}
