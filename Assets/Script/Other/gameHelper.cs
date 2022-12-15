using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHelper
{
    public class PlayerName
    {
        public string nameOfCharacter;
        public string SetPlayerName(string name)
        {
            nameOfCharacter = name;
            return nameOfCharacter;
        }
    }

    public class PlayerPosition
    {
        public Vector3 SetPlayerPosition()
        {
            return Vector2.zero;
        }
    }
}
