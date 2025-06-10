using TMPro;
using UnityEngine;

public class ItemMana : ItemPocao
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Atribuir a mana ao canvas
            CanvasGameMng.PnlStatusPlayer.IncrementarMana(porcentagemPocao);

            //Destruir o objeto
            Destroy(gameObject, Time.deltaTime);
        }
    }
}
