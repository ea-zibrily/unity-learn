using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMelee : weaponBase
{
    [Header("Scriptable Object")]
    public weaponDefinition _SOWeaponDefinition;

    /*
    [Header("Weapon Melee Component")]
    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        bulletVelocity = _SOWeaponDefinition.velocitySpeed;
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        weaponName = _SOWeaponDefinition.weaponName;
        weaponDamage = _SOWeaponDefinition.weaponDamage;
        weaponRange = _SOWeaponDefinition.weaponRange;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Weapon Name: " + weaponName);
        Debug.Log("Weapon Damage: " + weaponDamage);
        Debug.Log("Weapon Range: " + weaponRange);
    }
}
