using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public float consumoMana; //Variavel que vai dizer quanto de mana será consumida ao atacar
    public int idArma; //id da arma ativa
    public GameObject[] armas; //Armas do player
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Selecionar o cajado ao iniciar o jogo
        SelecionarArma(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar qual arma está ativa
        if (idArma == 0) { 
            //Atacar com o cajado
            AtacarCajado();
        }
    }

    private void AtacarCajado()
    {
        //Verificar se o input para atirar foi teclado e se tem mana para usar
        if(Input.GetAxis("Ataque") > 0 && 
           CanvasGameMng.PnlStatusPlayer.TemMana(consumoMana) == true)
        {
            //Chamar a animação de ataque
            PlayerMng.AnimacaoPlayer.PlayAtaque();
        }
        else if(Input.GetAxis("AtaqueConstante") > 0 &&
           CanvasGameMng.PnlStatusPlayer.TemMana() == true)
        {
            //Chamar a animação 
            PlayerMng.AnimacaoPlayer.PlayAtaqueConstante();
            //Consumir a mana
            CanvasGameMng.PnlStatusPlayer.ConsumirManaConstante();
        }
        else
        {
            //Chamar animação de parado
            PlayerMng.AnimacaoPlayer.PlayParado();
        }
    }

    private void SelecionarArma(int id)
    {
        //Desativar todos os objetos
        foreach (GameObject arma in armas)
        {
            arma.SetActive(false);
        }

        //Ativar a arma indicada
        armas[id].SetActive(true);
    }
}
