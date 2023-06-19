using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grade : MonoBehaviour
{
    public GameObject Portal;
    private Animator ControlAnim;
    // Start is called before the first frame update
    void Start()
    {
        ControlAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Player")
        {
            ControlAnim.SetBool("Ativado", true);
        }
    }
    private void Abrindo()
    {
        Portal.GetComponent<BGrade>().Abrir();
    }
}
