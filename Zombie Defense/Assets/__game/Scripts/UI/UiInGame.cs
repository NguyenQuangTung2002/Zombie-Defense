using System;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiInGame: UITemplate
{

    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnRepair;
    [SerializeField] private Button btnSkin;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button setting;
    [SerializeField] private Button btnReward;
    [SerializeField] private Button btnMissions;
    [SerializeField] private Button btnNextWorld;
    [SerializeField] private TextMeshProUGUI coinToPaid;
    
    private void Awake()
    {
        coinToPaid = btnRepair.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        btnStart.onClick.AddListener(OnClickStartBtn);
        btnRepair.onClick.AddListener(OnclickRepairBtn);
        btnSkin.onClick.AddListener(OnClickShopSkin);
        btnShop.onClick.AddListener(OnClickBtnShop);
        setting.onClick.AddListener(OnClickbtnSetting);
        btnReward.onClick.AddListener(OnClickBtnReward);
        btnMissions.onClick.AddListener(OnClickBtnMissions);
        btnNextWorld.onClick.AddListener(OnClickBtnNextWorld);
    }

    private void OnClickStartBtn()
    {
        WorldController.Instance.ChangeState(GameState.START_BATTLE);
        WorldController.Instance.worldLevelSystem.UpLevel();
    }

    private void OnclickRepairBtn()
    {
        DoorManager.Instance.RepairDoors();
        btnRepair.gameObject.SetActive(false);
        
        coinToPaid.text ="0";
    }

    public override void Show(bool isShown)
    {
        gameObject.SetActive(isShown);
        
        if (coinToPaid != null && DoorManager.Instance.PaidRepair()==0)
        {
            btnRepair.gameObject.SetActive(false);
        }
    }
    
    
    private void OnClickShopSkin()
    {
        GameManager.Instance.UiController.OpenShopCharacter();

        SoundManager.Instance.PlaySoundButton();
        WorldController.Instance.Pause();
    }

    private void OnClickBtnShop()
    {
        GameManager.Instance.UiController.OpenShopIap();

        SoundManager.Instance.PlaySoundButton();
        WorldController.Instance.Pause();
    }

    private void OnClickBtnReward()
    {
        GameManager.Instance.UiController.OpenDailyReward();

        SoundManager.Instance.PlaySoundButton();
        WorldController.Instance.Pause();
    }

    private void OnClickbtnSetting()
    {
        GameManager.Instance.UiController.OpenSetting();

        SoundManager.Instance.PlaySoundButton();
        WorldController.Instance.Pause();
    }

    private void OnClickBtnMissions()
    {
        GameManager.Instance.UiController.OpenMissiosnBoard();
        
        SoundManager.Instance.PlaySoundButton();
        WorldController.Instance.Pause();
    }

    private void OnClickBtnNextWorld()
    {
        if (GameManager.Instance == null)
        {
            Debug.Log("Khong ton tai GameManager");
            return;
        }
        
        GameManager.Instance.CurrentLevelManager.StartLevel();
        btnNextWorld.gameObject.SetActive(false);
    }

    public void ShowStartBattleUI()
    {
        
    }

    public void HideStartBattleUI()
    {
        
    }

    public void ShowEnterGameUI()
    {
        btnMissions.gameObject.SetActive(true);
        btnStart.gameObject.SetActive(true);
        btnReward.gameObject.SetActive(true);
        if (coinToPaid != null && DoorManager.Instance.PaidRepair()>0)
        {
            coinToPaid.text = DoorManager.Instance.PaidRepair().ToString();
            btnRepair.gameObject.SetActive(true);
        }
    }

    public void HideEnterGameUI()
    {
        btnMissions.gameObject.SetActive(false);
        btnStart.gameObject.SetActive(false);
        btnRepair.gameObject.SetActive(false);
        btnReward.gameObject.SetActive(false);
    }

    public void ShowFinishWorldUI()
    {
        btnNextWorld.gameObject.SetActive(true);
    }

    public void HideFinishWorldUI()
    {
        btnNextWorld.gameObject.SetActive(false);
    }
}