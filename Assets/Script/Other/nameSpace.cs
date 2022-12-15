using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelper;

public class nameSpace : MonoBehaviour
{
    [SerializeField] private string nameNaon;
    public string setName;
    // Start is called before the first frame update
    void Start()
    {
        /*
        //use namespace component without using namespace
        GameHelper.PlayerName player = new GameHelper.PlayerName();
        setName = player.SetPlayerName(nameNaon);
        Debug.Log(setName);
        */

        //use namespace component with using namespace
        //sama kek OOP, jadi kita bisa langsung create
        //object class yang ada pada namespace GameHelper
        PlayerName player = new PlayerName();
        setName = player.SetPlayerName(nameNaon);
        Debug.Log(setName);

        /*
        //another way to use class in GameHelper namespace
        setName = new PlayerName().SetPlayerName(nameNaon);
        Debug.Log(setName);
        transform.position = new PlayerPosition().SetPlayerPosition();
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
