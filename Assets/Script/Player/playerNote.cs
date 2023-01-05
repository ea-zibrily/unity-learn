using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNote : MonoBehaviour
{

    // Path: Assets\Script\Player\playerNote.cs
    // Compare this snippet from Assets\Script\Player\playerMove.cs

    /*
    
        // Compare Code #1
        // Code buat atur direction player waktu ngelock target
            if (aimDir > 0 && !isLock)
            {
                myAnim.SetFloat("Hori", targetDirection.x);
                myAnim.SetFloat("Vert", targetDirection.y);
            }
            else if (aimDir < 0 && !isLock)
            {
                transform.localScale = new Vector2(-1, 1);
            }

            float aimX, aimY;
            #region AimX
            if (crossHair.transform.position.x <= 0)
            {
                aimX = crossHair.transform.position.x / (crossHair.transform.position.x * (-1));
            }
            else
            {
                aimX = crossHair.transform.position.x / crossHair.transform.position.x;
            }
            #endregion

            #region AimY
            if (crossHair.transform.position.y <= 0)
            {
                aimY = crossHair.transform.position.y / (crossHair.transform.position.y * (-1));
            }
            else
            {
                aimY = crossHair.transform.position.y / crossHair.transform.position.y;
            }
            #endregion

            targetDirection = new Vector2(aimX, aimY);

    */
}
