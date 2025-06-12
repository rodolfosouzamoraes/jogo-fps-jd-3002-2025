using UnityEngine;

public class PnlLoja : MonoBehaviour
{
    public GameObject pnlLoja;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pnlLoja.SetActive(false);
    }

    public void ExibirPainelLoja()
    {
        gameObject.SetActive(true);
    }
    public void OcultarPainelLoja()
    {
        gameObject.SetActive(false);
    }
}
