using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string whatUrName;

    private void Start()
    {
        whatUrName = PlayerManager.Instance.PrintPlayerName(whatUrName);
        Debug.Log(whatUrName);
    }
}
