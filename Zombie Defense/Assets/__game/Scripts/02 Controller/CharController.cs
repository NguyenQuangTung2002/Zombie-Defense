using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharController : MonoBehaviour
{
    public static CharController Instance;
    [SerializeField] private Joystick joystick;
    public Ragdoll ragdoll;

    public AttackRadius attackRadius;
    public Damageable enemy { get; private set; }
    public Vector3 moveJoystick { get; private set; }
    public CharFSM stateController { get; private set; }
    

    private void Awake()
    {
        Instance = this;
        stateController = new CharFSM(this);
        attackRadius.OnAttack += setState;
    }

    private void Start()
    {
        ragdoll = Character.Instance.GetComponent<Ragdoll>();
        stateController.ChangeState(CharState.Normal);
        
        if (GameManager.Instance != null)
        {
            joystick = GameManager.Instance.UiController.ObjJoyStick;
        }
    }

    void Update()
    {
      
        if(joystick != null)
        {
            Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            moveJoystick = movement;
        }

        stateController.Update();
    }

    private void setState(Damageable target)
    {
        if (stateController.currentCharState == CharState.Normal
            || stateController.currentCharState == CharState.Attack)
        {
            if (enemy != target) enemy = target;

            if (target != null && stateController.currentCharState == CharState.Normal)
            {
                ChangeState(CharState.Attack);
                attackRadius.OnAttack +=  AttackEnemy;
                //Character.Instance.currentWeapon.Attack(enemy);
            }
            else if (target == null && stateController.currentCharState == CharState.Attack)
            {
                attackRadius.OnAttack -=  AttackEnemy;
                ChangeState(CharState.Normal);
            }
        }
    }
    
    
    public void AttackEnemy(Damageable target)
    {
        Character.Instance.GetEnemy(target);
    }
    

    public void ChangeState(CharState state)
    {
        stateController.ChangeState(state);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        Character.Instance.currentWeapon = weapon;
    }

    public void ChangeCharAnim(AnimatorOverrideController overrideController)
    {
        Character.Instance.animator.runtimeAnimatorController = overrideController;
    }
}