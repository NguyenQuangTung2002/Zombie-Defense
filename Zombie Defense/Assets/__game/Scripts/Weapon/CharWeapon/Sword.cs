using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Sword : MeleeWeapon
{
    private float animSpeed;
    private float fxSpeed;

    protected override void Start()
    {
        animSpeed = 1f;
        fxSpeed = 0.7f;
        animSpeed = 1f;
        effectAttack = new Dictionary<string, ParticleSystem>();

        Init();
        
        CharController.Instance.attackRadius.attackDelay = 0.5f;
        CharController.Instance.attackRadius.timeLoadDelay = 0.4f;
        Character.Instance.animator.SetFloat("AttackSpeed", animSpeed);
    }

    void Init()
    {
        if (effectPrefab.ContainsKey("SwordSlash"))
        {
            ParticleSystem effect = Instantiate(effectPrefab["SwordSlash"], Character.Instance.transform.GetChild(8).transform);
            effectAttack.Add("SwordSlash",effect);
            effect.gameObject.SetActive(false);
            effect.transform.localScale = new Vector3(2.3f, 2.3f, 2.3f);
            var main = effect.main;
            main.simulationSpeed = fxSpeed;
        }
    }

    protected override void AttackMethod()
    {
    }
}