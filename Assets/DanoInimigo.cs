using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public float vida;
    private InstanciarInimigos controladorDeNovoInimigos;
    
    public void EfetuarDano(float dano)
    {
        //Remover o valor do dano na vida do inimigo
        vida -= dano;

        //verificar se o inimigo ficou sem vidas
        if(vida <= 0)
        {
            //Remover da contagem de inimigos na fase
            controladorDeNovoInimigos.DecrementarInimigosInstanciados();

            //Destruir o inimigo
            Destroy(gameObject);
        }
    }

    public void ReferenciarInimigo(InstanciarInimigos referencia)
    {
        controladorDeNovoInimigos = referencia;
    }
}
