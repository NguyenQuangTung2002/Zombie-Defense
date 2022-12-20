using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponData
{
    public bool unlock { get; set; }
    public int rate { get; set; }
    public int damage { get; set; }
}

public class WeaponFormData
{
    public bool unlock;
    public int rate;
    public int damage;
}
