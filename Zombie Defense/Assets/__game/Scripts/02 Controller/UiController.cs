using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public UiFinishWorld uiFinishWorld;
    public UiMainLobby UiMainLobby;
    public UiLose UiLose;
    public UiWin UiWin;
    public UiInGame UiInGame;
    public ShopCharacter ShopCharater;
    public MissionsBoard missionsBoard;
    public ShopIAP ShopIap;
    public DailyReward DailyReward;
    public Setting Setting;
    public UiTop UiTop;
    //public UiLeaderBoardIngame UiLeaderboard;
    public PopupRewardEndGame PopupRewardEndGame;
    public PopupChestKey PopupChestKey;
    public LuckyWheel LuckeyWheel;
    public GameObject Loading;
    public GameObject ObjTutHand;
    //public PopupShowRewards PopupShowRewards;

    public Joystick ObjJoyStick;
    

    public void Init()
    {
        UltimateJoystick.DisableJoystick(Constants.MAIN_JOINSTICK);
    }

    public void OpenUiLose()
    {
        UiLose.Show(true);
    }
    
#region New

    public void OpenUIInGame()
    {
        UiInGame.Show(true);
    }

    public void CloseUIInGame()
    {
        UiInGame.Show(false);
    }

    public void OpenUIFinishWorld()
    {
        uiFinishWorld.Show(true);
    }
    
    public void OpenMissiosnBoard()
    {
        missionsBoard.Show(true);
    }

#endregion
   

    public void OpenUiWin(int gold)
    {
        UiWin.Show(true);
        UiWin.Init(gold);
    }

    public void OpenShopCharacter()
    {
        ShopCharater.Show(true);
    }

    public void OpenDailyReward()
    {
        DailyReward.Show(true);
    }

    public void OpenSetting()
    {
        Setting.Show(true);
    }

    public void OpenShopIap()
    {
        ShopIap.Show(true);
    }

    public void OpenPopupReward(RewardEndGame reward, TypeDialogReward type)
    {
        if (PopupRewardEndGame.IsShow)
            return;

        PopupRewardEndGame.Show(true);
        PopupRewardEndGame.Init(reward, type);
    }

    public void OpenPopupChestKey(RewardEndGame reward)
    {
        PopupChestKey.Show(true);
        PopupChestKey.Init(reward);
    }

    public void OpenLuckyWheel()
    {
        LuckeyWheel.Show(true);
    }

    public void OpenLoading(bool isLoading)
    {
        Loading.SetActive(isLoading);
    }

    public void ActiveTutHand(bool isActive)
    {
        ObjTutHand.SetActive(isActive);
    }

}

