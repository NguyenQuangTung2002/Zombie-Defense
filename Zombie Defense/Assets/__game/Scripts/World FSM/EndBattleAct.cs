using System.Collections;
using System.Collections.Generic;
using Common.FSM;
using UnityEngine;

public class EndBattleAct : FSMAction
{
    private readonly WorldController worldCtrl;

    public EndBattleAct(WorldController worldController, FSMState owner) : base(owner)
    {
        worldCtrl= worldController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        UltimateJoystick.DisableJoystick(Constants.MAIN_JOINSTICK);
        foreach (var elevantor in worldCtrl.elevantors)
        {
            if (elevantor != null)
            {
                elevantor.Init();
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        UltimateJoystick.EnableJoystick(Constants.MAIN_JOINSTICK);
    }
}
