using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrade : MonoBehaviour
{
    private Animator ControlAnim;
    // Start is called before the first frame update
    void Start()
    {
        ControlAnim = GetComponent<Animator>();
    }

    public void Abrir()
    {
        ControlAnim.SetBool("Ativado", true);
    }
}
