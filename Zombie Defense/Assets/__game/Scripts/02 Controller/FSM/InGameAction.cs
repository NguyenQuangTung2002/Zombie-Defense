using Common.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InGameAction : FSMAction
{
    private readonly GameManager gameManager;

    public InGameAction(GameManager _gameController, FSMState owner) : base(owner)
    {
        gameManager = _gameController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
      
        GameManager.Instance.UiController.OpenUIInGame();
        //WorldController.Instance.ChangeState(GameState.ENTER_GAME);
        
        if (GameManager.Instance.MainCamera != null) 
        {
            CameraFollowChar.Instance.GetComponent<UniversalAdditionalCameraData>().
                cameraStack.Add(GameManager.Instance.MainCamera.Camera);
            GameManager.Instance.MainCamera = CameraFollowChar.Instance;
        }
        GameManager.Instance.UiController.ObjJoyStick.gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        SoundManager.Instance.StopSound(SoundManager.GameSound.BGM);
    }
}
