using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public float vida;
    
    public void EfetuarDano(float dano)
    {
        //Remover o valor do dano na vida do inimigo
        vida -= dano;

        //verificar se o inimigo ficou sem vidas
        if(vida <= 0)
        {
            //Destruir o inimigo
            Destroy(gameObject);
        }
    }
}
