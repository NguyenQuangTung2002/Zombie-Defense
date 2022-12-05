using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MeleeWeapon
{
    
    private float animSpeed;
    protected override void Start()
    {
        animSpeed = 1f;
        effectAttack = new Dictionary<string, ParticleSystem>();

        Init();
        
        CharController.Instance.attackRadius.attackDelay =0.5f;
        CharController.Instance.attackRadius.timeLoadDelay =0.4f;
        Character.Instance.animator.SetFloat("AttackSpeed",animSpeed);
    }

    void Init()
    {
        if (effectPrefab.ContainsKey("BatSlash"))
        {
            ParticleSystem batSlash = Instantiate(effectPrefab["BatSlash"], Character.Instance.transform.GetChild(9).transform);
            effectAttack.Add("BatSlash",batSlash);
            batSlash.gameObject.SetActive(false);
            batSlash.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (effectPrefab.ContainsKey("BatExplosion"))
        {
            ParticleSystem batExplosion = Instantiate(effectPrefab["BatExplosion"], Character.Instance.transform.GetChild(9).transform);
            effectAttack.Add("BatExplosion",batExplosion);
            batExplosion.gameObject.SetActive(false);
            batExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    protected override void AttackMethod()
    {
        
        
    }
}
