using System;
using UnityEngine;

[Serializable]
public class LevelCharSpeed
{
    [SerializeField] public float speed;
    [SerializeField] public int coinUpgrade;
}

[Serializable]
public class LevelCharHealh
{
    [SerializeField] public int health;
    [SerializeField] public int coinUpgrade;
}
[Serializable]
public class LevelTrap
{
    [SerializeField] public int damage;
    [SerializeField] public int coinUpgrade;
}

[Serializable]
public class LevelSentryTower
{
    [SerializeField] public int damage;
    [SerializeField] public int coinUpgrade;
    [SerializeField] public int coinUnlock;
}

[Serializable]
public class LevelDoor
{
    [SerializeField] public int health;
    [SerializeField] public int coinUpgrade;
}
