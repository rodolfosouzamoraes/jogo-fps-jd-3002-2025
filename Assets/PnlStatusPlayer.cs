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

    [Header("Config Vida")]
    public float vidaMax;
    public float vidaAtual;
    public Slider vidaSlider;
    public TextMeshProUGUI txtVida;

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

        //Definir a vida atual
        vidaAtual = vidaMax;

        //Configurar o slider
        vidaSlider.maxValue = vidaMax;
        vidaSlider.minValue = 0;
        vidaSlider.value = vidaAtual;

        //Configurar o texto da vida
        txtVida.text = $"{vidaAtual}/{vidaMax}";
    }

    private void AtualizarStatusMana()
    {
        manaSlider.value = manaAtual;
        txtMana.text = $"{(int)manaAtual}/{manaMax}";
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

    public void IncrementarMana(float porcentagem)
    {
        //Calcular a mana adquirida
        float calculoMana = manaMax * porcentagem;

        //Incrementar na mana atual
        manaAtual += calculoMana;

        //Verificar se a mana ultrassou o limite máximo
        if(manaAtual > manaMax)
        {
            //Limito a mana atual ao valor máximo
            manaAtual = manaMax;
        }

        //Atualizar o status da mana
        AtualizarStatusMana();
    }

    private void AtualizarStatusVida()
    {
        vidaSlider.value = vidaAtual;
        txtVida.text = $"{vidaAtual}/{vidaMax}";
    }

    public void ConsumirVidaPlayer(float valorConsumido)
    {
        vidaAtual -= valorConsumido;

        if (vidaAtual <= 0) { 
            vidaAtual = 0;
            //Game Over            
        }

        AtualizarStatusVida();
    }

    public void IncrementarVidaPlayer(float porcentagem)
    {
        float calculoVida = vidaMax * porcentagem;

        vidaAtual += calculoVida;

        if (vidaAtual > vidaMax)
        {
            vidaAtual = vidaMax;
        }

        AtualizarStatusVida();
    }
}
