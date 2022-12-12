using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBase : MonoBehaviour
{
    private string _weaponName;
    private int _weaponDamage;
    private float _weaponRange;
    private int _weaponCost;

    public string weaponName
    {
        get { return _weaponName; }
        set { _weaponName = value; }
    }
    public int weaponDamage
    {
        get { return _weaponDamage; }
        set { _weaponDamage = value; }
    }
    public float weaponRange
    {
        get { return _weaponRange; }
        set { _weaponRange = value; }
    }
    public int weaponCost
    {
        get { return _weaponCost; }
        set { _weaponCost = value; }
    }
}
