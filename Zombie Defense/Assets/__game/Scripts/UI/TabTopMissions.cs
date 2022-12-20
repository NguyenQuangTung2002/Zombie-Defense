using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabTopMissions : MonoBehaviour
{
    [SerializeField] private TypeTabShopCharacter type;
    [SerializeField] private Button btnTab;
    [SerializeField] private List<Sprite> listSprStateTabs;
    [SerializeField] private Image imgButton;

    private MissionsBoard _missionsBoardContrl;
    private void Start()
    {
        btnTab.onClick.AddListener(OnClickBtnTab);
    }

    public void Init(MissionsBoard missionsBoardController)
    {
        _missionsBoardContrl = missionsBoardController;
    }

    public void ActiveTab()
    {
        imgButton.sprite = listSprStateTabs[0];
    }

    public void DisableTab()
    {
        imgButton.sprite = listSprStateTabs[1];
    }

    private void OnClickBtnTab()
    {
        _missionsBoardContrl.ActiveContentTab((int)type);

        SoundManager.Instance.PlaySoundButton();
    }
}