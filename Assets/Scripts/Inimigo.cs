using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hp = 5;
    public GameObject AreaDeAtk;

    private void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Ataque")
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
    public void AtivarAtk()
    {
        AreaDeAtk.SetActive(true);
    }
    public void DesativarAtk()
    {
        AreaDeAtk.SetActive(false);
    }
}
