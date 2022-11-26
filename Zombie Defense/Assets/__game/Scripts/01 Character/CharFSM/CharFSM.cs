using System;
using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class CharFSM : FSM
{
    public CharState currentCharState { get; private set; }

    private FSMState waitingState;
    private WaitAct wait;
    
    private FSMState normalState;
    private NormalAct normal;
    
    private FSMState attackState;
    private AttackAct attack;
    
    private FSMState deathState;
    private DieAct die;
    
    private FSMState reviveState;
    private ReviveAct revive;
    
    public CharFSM(CharController charController) : base("Char FSM")
    {
        waitingState = this.AddState((byte)CharState.Waiting);
        normalState =this.AddState((byte)CharState.Normal);
        attackState = this.AddState((byte)CharState.Attack);
        deathState = this.AddState((byte)CharState.Dead);
        reviveState = this.AddState((byte) CharState.Revive);

        wait = new WaitAct(charController, waitingState);
        normal = new NormalAct(charController, normalState);
        attack = new AttackAct(charController, attackState);
        die = new DieAct(charController, deathState);
        revive = new ReviveAct(charController, reviveState);
        
        waitingState.AddAction(wait);
        normalState.AddAction(normal);
        attackState.AddAction(attack);
        deathState.AddAction(die);
        reviveState.AddAction(revive);
    }

    public void ChangeState(CharState state)
    {
        //Crashlytics.Log($"Change from state {this.currentState} to {state}");
        switch (state)
        {
            case CharState.Waiting:
                ChangeToState(waitingState);
                currentCharState = CharState.Waiting;
                break;
            case CharState.Normal:
                ChangeToState(normalState);
                currentCharState = CharState.Normal;
                break;
            case CharState.Attack:
                ChangeToState(attackState);
                currentCharState = CharState.Attack;
                break;
            case CharState.Dead:
                ChangeToState(deathState);
                currentCharState = CharState.Dead;
                break;
            case CharState.Revive:
                ChangeToState(reviveState);
                currentCharState = CharState.Revive;
                break;
            default:
                break;
        }
    }

   
}
