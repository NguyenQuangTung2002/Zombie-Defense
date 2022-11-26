using System;
using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class NormalAct :FSMAction
{
    private readonly CharController characterCtrl;
    private Animation aim;

    public NormalAct(CharController characterController, FSMState owner) : base(owner)
    {
        characterCtrl= characterController;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
       
        Character.Instance.Look(characterCtrl.moveJoystick);
        Character.Instance.Move(characterCtrl.moveJoystick);
        
        //Change Anim and Anim speed
        float velocity = (float)(Math.Pow(characterCtrl.moveJoystick.x, 2) + Math.Pow(characterCtrl.moveJoystick.z, 2));
        
        float targetDir = Vector3.Angle(characterCtrl.moveJoystick.normalized, Character.Instance.transform.forward);
        var newVector =  new Vector3(-Mathf.Sin(targetDir), 0,  Mathf.Cos(targetDir));
        
        Character.Instance.animator.SetFloat("Velocity",velocity);
        Character.Instance.animator.SetFloat("StrafeX",newVector.x);
        Character.Instance.animator.SetFloat("StrafeY",newVector.z);
     
    }
    
}