using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiFinishWorld: UITemplate
{
    public static UiFinishWorld Instance;

    [SerializeField] private Button nextWorld;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextWorld.onClick.AddListener(OnClickNextBtn);
    }

    private void OnClickNextBtn()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CurrentLevelManager.StartLevel();
        }
        else
        {
            Debug.Log("khong ton tai GameManager");
        }
    }
    
    public override void Show(bool isShown)
    {
        base.Show( isShown && DoorManager.Instance.PaidRepair()>0);
        if (!isShown)
        {
            ActiveBtn(false);
        } else
        {
            ActiveBtn(true);
        }
    }
    
    private void ActiveBtn(bool state)
    {
        this.gameObject.SetActive(true);
    }
}