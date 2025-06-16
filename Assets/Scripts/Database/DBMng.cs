using UnityEngine;

public static class DBMng
{
    private const string PLAYER_DATA = "player-data";

    public static Player ObterDadosPlayer()
    {
        //Pegar a estrutura json que está salva na memória
        string json = PlayerPrefs.GetString(PLAYER_DATA);

        //Converter os dados para a classe Player
        Player player = JsonUtility.FromJson<Player>(json);

        return player;
    }
}
