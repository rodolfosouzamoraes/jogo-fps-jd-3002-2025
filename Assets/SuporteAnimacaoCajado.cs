using UnityEngine;

public class SuporteAnimacaoCajado : MonoBehaviour
{
    public void ConsumirMana()
    {
        //Pegar o consumo de mana do player
        float mana = PlayerMng.AtaquePlayer.consumoMana;

        //Consumir a mana na UI
        CanvasGameMng.PnlStatusPlayer.ConsumirMana(mana);
    }
}
