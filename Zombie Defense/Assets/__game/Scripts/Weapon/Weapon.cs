using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Weapon : SerializedMonoBehaviour
{
    
    public Dictionary<string,ParticleSystem> effectPrefab;
    public Dictionary<string,ParticleSystem> effectAttack;
    public virtual void Attack(Damageable damageable)
    {
    }
}
