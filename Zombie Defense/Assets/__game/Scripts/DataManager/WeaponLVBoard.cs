using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLVBoard", menuName = "BoardLV/WeaponLVBoard")]

public class WeaponLVBoard : SerializedScriptableObject
{
    public Dictionary<WeaponType,LevelWeapon> weapon;
}


public class LevelWeapon
{
    public Dictionary<int, DataWeapon> data;
}


public class DataWeapon
{
    public int damage;
    public int coinUpgrageDmg;
    public int speed;
    public int coinUpgrageSpeed;
}