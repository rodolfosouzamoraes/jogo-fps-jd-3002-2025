using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PnlStatusPlayer : MonoBehaviour
{
    [Header("Config Mana")]
    public float manaMax; //Valor máximo da mana do player
    public float manaAtual; //valor atual da mana
    public float consumoConstante; //valor constante do consumo da mana
    public Slider manaSlider; //Slider da mana
    public TextMeshProUGUI txtMana; // TextMeshPro da mana
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir a mana no máximo ao iniciar o jogo
        manaAtual = manaMax;

        //Configurar o slider
        manaSlider.maxValue = manaMax;
        manaSlider.minValue = 0;
        manaSlider.value = manaAtual;

        //Configurar o texto da mana
        txtMana.text = $"{manaAtual}/{manaMax}";
    }

    private void AtualizarStatusMana()
    {
        manaSlider.value = manaAtual;
        txtMana.text = $"{manaAtual}/{manaMax}";
    }

    public void ConsumirMana(float consumo)
    {
        //Verificar se tem mana
        if(manaAtual >= consumo)
        {
            //Remover a quantidade de mana
            manaAtual -= consumo;

            //Atualizar o status da mana
            AtualizarStatusMana();
        }
    }

    public void ConsumirManaConstante()
    {
        //Consumir a mana
        manaAtual -= consumoConstante * Time.deltaTime;

        //Verificar se a mana acabou
        if(manaAtual <= 0)
        {
            manaAtual = 0;
        }

        //Atualizar o status da mana
        AtualizarStatusMana();
    }

    public bool TemMana(float consumo)
    {
        return manaAtual >= consumo;
    }

    public bool TemMana()
    {
        return manaAtual > 0;
    }
}
