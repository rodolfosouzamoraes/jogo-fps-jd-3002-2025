using UnityEngine;

public class PlayerMng : MonoBehaviour
{
    public static PlayerMng Instance;
    public static MovimentarPlayer MovimentarPlayer;
    public static AnimacaoPlayer AnimacaoPlayer;
    public static AtaquePlayer AtaquePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance == null)
        {
            MovimentarPlayer = GetComponent<MovimentarPlayer>();
            AnimacaoPlayer = GetComponent<AnimacaoPlayer>();
            AtaquePlayer = GetComponent<AtaquePlayer>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
