using TMPro;
using UnityEngine;

public class ItemPocao : MonoBehaviour
{
    public TextMeshProUGUI txtPorcentagemPocao;
    private float valorPocao;
    protected float porcentagemPocao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sortear um valor para a mana
        valorPocao = new System.Random().Next(25, 76);

        //Atualizar o texto da porcentagem mana
        txtPorcentagemPocao.text = $"{valorPocao}%";

        //Definir a porcentagem em numero decimal
        porcentagemPocao = valorPocao / 100;
    }

}
