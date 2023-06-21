using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenu : MonoBehaviour
{

    [SerializeField] private string NomeDoLevelJogo;
    [SerializeField] private GameObject PainelMenuInical;
    [SerializeField] private GameObject PainelOptions;
    [SerializeField] private GameObject PainelCred;

   public void Jogar() 
    {
        SceneManager.LoadScene(NomeDoLevelJogo);
    }
 
  public void OpenOpt()
    {
        PainelMenuInical.SetActive(false);
        PainelOptions.SetActive(true);

    }
  public void FecharOpt()
    {
        PainelOptions.SetActive(false);
        PainelMenuInical.SetActive(true);
    }

    public void OpenCred()
    {
        PainelMenuInical.SetActive(false);
        PainelCred.SetActive(true);

    }
    public void FecharCred()
    {
        PainelCred.SetActive(false);
        PainelMenuInical.SetActive(true);
    }


    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

   public void Greetings()
    {
        SceneManager.LoadScene("Agradecimentos");
    }
}
