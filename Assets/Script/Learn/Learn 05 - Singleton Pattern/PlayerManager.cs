using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    private string playerName;

    public string PrintPlayerName(string name)
    {
        playerName = name;
        return playerName;
    }
}
