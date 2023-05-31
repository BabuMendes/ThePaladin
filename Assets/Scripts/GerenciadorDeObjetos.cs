using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDeObjetos : MonoBehaviour
{

    public List<GameObject> Bolsa;
    public List<string> NomesNaBolsa;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool ReceberItem(string nomeObj, Sprite imgObj)
    {

        if (Bolsa[0].GetComponent<Image>().sprite == null)
        {
            NomesNaBolsa[0] = nomeObj;
            Bolsa[0].GetComponent<Image>().sprite = imgObj;
            return true;
        }
        else if (Bolsa[1].GetComponent<Image>().sprite == null)
        {
            NomesNaBolsa[1] = nomeObj;
            Bolsa[1].GetComponent<Image>().sprite = imgObj;
            return true;
        }
        else if (Bolsa[2].GetComponent<Image>().sprite == null)
        {
            NomesNaBolsa[2] = nomeObj;
            Bolsa[2].GetComponent<Image>().sprite = imgObj;
            return true;
        }
        else
        {
            return false;
        }
    }
}
