using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponDefinition", menuName = "Weapon/New Weapon", order = 1)]
public class weaponDefinition : ScriptableObject
{
    public string weaponName;
    public weaponType weaponType;
    [TextArea(3, 10)]
    public string weaponDescription;
    public int weaponDamage;
    public float weaponRange;
    public float velocitySpeed;
    public float betweenAttackTime;
    public float weaponAmmo;
    public float weaponMagazineLimit;
    public int weaponCost;
    public int weaponMasteryGain;

}
