using System;
using System.Collections;
using System.Collections.Generic;
using RocketTeam.Sdk.Services.Ads;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DailyReward : UICanvas
{
    [Header("Main button")] 
    [SerializeField] private List<Button> btnGetRewards; 
    [SerializeField] private List<Image> rewardImages;
    [SerializeField] private List<TextMeshProUGUI> rewardAmountTexts;
    [SerializeField] private List<Image> claimed;
    [SerializeField] private List<Image> locks;
    [SerializeField] private Button claim;
    [SerializeField] private Button getX2;

    [Space] 
    [Header("Rewards Images")] 
    [SerializeField] Sprite iconCoinsSprite;
    [SerializeField] Sprite iconGemsSprite;

    [Space] [Header("FX")] 
    [SerializeField] ParticleSystem fxCoins;
    [SerializeField] ParticleSystem fxGems;

    [Space] 
    [Header("Rewards Database")] 
    [SerializeField] private DailyRewardData dailyRewardData;

    private int nextRewardIndex;
    
 
    void Start()
    {
        Initialize();
        CheckIndex();
        ActivateDayReward();
    }

    void Initialize()
    {
        nextRewardIndex = PlayerPrefs.GetInt("Reward_Next_Index");
        
        //Add Click Events

        claim.onClick.RemoveAllListeners();
        claim.onClick.AddListener(OnClaimClick);
        getX2.onClick.AddListener(OnClickGetX2);
        btnGetRewards[0].onClick.AddListener(() => GetReward(0));
        btnGetRewards[1].onClick.AddListener(() => GetReward(1));
        btnGetRewards[2].onClick.AddListener(() => GetReward(2));
        btnGetRewards[3].onClick.AddListener(() => GetReward(3));
        btnGetRewards[4].onClick.AddListener(() => GetReward(4));
        btnGetRewards[5].onClick.AddListener(() => GetReward(5));
        btnGetRewards[6].onClick.AddListener(() => GetReward(6));
        

        //Check if the game is opened for the first time then set Reward_Claim_Datetime to the current datetime
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Reward_Claim_Datetime")))
            PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());
        
    }
    

   

    void ActivateDayReward()
    {

        for(int i=0; i<= nextRewardIndex; i++)
        {
            //Set state unlock day reward
            RewardDay reward = dailyRewardData.Days[i];
            
            //icon
            if (reward.Type == RewardType.GOLD)
                rewardImages[i].sprite = iconCoinsSprite;
            else
                rewardImages[i].sprite = iconGemsSprite;
            rewardAmountTexts[i].text = string.Format("+{0}", reward.Amount);
            locks[i].gameObject.SetActive(false);
            
            if ( PlayerPrefs.GetString("Reward_State_" + i) != "Claimed")
            {
                PlayerPrefs.SetString("Reward_State_" + i, "Unlock");
            }
            else
            {
                claimed[i].gameObject.SetActive(true);
            }
          
        }
        
        for(int i = nextRewardIndex+1; i< 7; i++)
        {
            //Set state lock day reward
            RewardDay reward = dailyRewardData.Days[i];

            //icon
            if (reward.Type == RewardType.GOLD)
                rewardImages[i].sprite = iconCoinsSprite;
            else
                rewardImages[i].sprite = iconGemsSprite;
            rewardAmountTexts[i].text = string.Format("+{0}", reward.Amount);
            
            if (PlayerPrefs.GetString("Reward_State_" + i) != "Claimed")
            {
                locks[i].gameObject.SetActive(true);
                PlayerPrefs.SetString("Reward_State_" + i, "Lock");
            }
            else 
            {
                locks[i].gameObject.SetActive(false);
                claimed[i].gameObject.SetActive(true);
            }

        }
        
    }

    void GetReward(int index)
    {
        Debug.Log(index);
        RewardDay reward = dailyRewardData.Days[index];

        String rewardState = PlayerPrefs.GetString("Reward_State_"+index);

        //check reward type
        if (reward.Type == RewardType.GOLD && rewardState  == "Unlock")
        {
          
            Debug.Log("<color=yellow>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
            Wallet.Instance.AddCoins(reward.Amount);
            fxCoins.Play();
            claimed[index].gameObject.SetActive(true);
            PlayerPrefs.SetString("Reward_State_" + index, "Claimed");
            SaveNextRewardIndex();
        }
        else if(reward.Type == RewardType.GEM && rewardState == "Unlock")
        {
            Debug.Log("<color=green>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
            Wallet.Instance.AddGems(reward.Amount);
            fxGems.Play();
            claimed[index].gameObject.SetActive(true);
            PlayerPrefs.SetString("Reward_State_" + index, "Claimed");
            SaveNextRewardIndex();
   
        }
        

    }
    

    void OnClaimClick()
    {
        for(int i=0; i<= nextRewardIndex; i++)
        {
            RewardDay reward = dailyRewardData.Days[i];

            String rewardState = PlayerPrefs.GetString("Reward_State_"+i);

            //check reward type
            if (reward.Type == RewardType.GOLD && rewardState  == "Unlock")
            {
          
                Debug.Log("<color=yellow>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
                Wallet.Instance.AddCoins(reward.Amount);
                fxCoins.Play();
                claimed[i].gameObject.SetActive(true);
                PlayerPrefs.SetString("Reward_State_" + i, "Claimed");
                SaveNextRewardIndex();
            }
            else if(reward.Type == RewardType.GEM && rewardState == "Unlock")
            {
                Debug.Log("<color=green>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
                Wallet.Instance.AddGems(reward.Amount);
                fxGems.Play();
                claimed[i].gameObject.SetActive(true);
                PlayerPrefs.SetString("Reward_State_" + i, "Claimed");
                SaveNextRewardIndex();
   
            }
        }
        
       
    }

    void SaveNextRewardIndex()
    {
        DateTime rewardClaimDatetime =
            DateTime.Parse(PlayerPrefs.GetString("Reward_Claim_Datetime"));

        if((DateTime.Now -rewardClaimDatetime).TotalSeconds > 1)nextRewardIndex++;


        PlayerPrefs.SetInt("Reward_Next_Index", nextRewardIndex);

        //Save DateTime of the last Claim Click
        PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());
    }

    void CheckIndex()
    {
        if (nextRewardIndex >= dailyRewardData.Days.Count)
        {
            nextRewardIndex = 0;
            for (int i = 0; i < 7; i++)
            {
                PlayerPrefs.SetString("Reward_State_"+i,"Lock");
                locks[i].gameObject.SetActive(true);
                claimed[i].gameObject.SetActive(false);
            }
        }
        PlayerPrefs.SetInt("Reward_Next_Index", nextRewardIndex);
    }

    void OnClickGetX2()
    {
        Observable.FromCoroutine(ActionWatchVideo).Subscribe().AddTo(this.gameObject);
    }
    
    private IEnumerator ActionWatchVideo()
    {
        float _tmp1 = 0;
        float _tmp2 = 1;
        RewardAdStatus _rewardAdStatus = RewardAdStatus.NoVideoNoInterstitialReward;
        while (_tmp1 < 2)
        {
            _tmp1 += Time.deltaTime;
            _tmp2 += Time.deltaTime;
            if (_tmp2 > 0.5f)
            {
                _tmp2 = 0;
                _rewardAdStatus = AdManager.Instance.ShowAdsReward(OnRewardedVideo, Helper.video_shop_skin, false);
                switch (_rewardAdStatus)
                {
                    case RewardAdStatus.NoInternet:
                        WaitingCanvas.Instance.Hide();
                        PopupDialogCanvas.Instance.Show("No Internet!");

                        Analytics.LogEventByName("Monetize_reward_no_internet");
                        Analytics.LogEventByName("Monetize_interstitial_no_internet");
                        yield break;
                    case RewardAdStatus.NoVideoNoInterstitialReward:
                        break;
                    default:
                        WaitingCanvas.Instance.Hide();
                        yield break;
                }
            }
            yield return null;
        }
        if (_rewardAdStatus == RewardAdStatus.NoVideoNoInterstitialReward)
        {
            WaitingCanvas.Instance.Hide();
            PopupDialogCanvas.Instance.Show("No Video!");
            Analytics.LogEventByName("Monetize_no_reward");
            Analytics.LogEventByName("Monetize_no_reward_no_interstitial");
        }
    }
    
    private void OnRewardedVideo(int x)
    {
        Debug.Log("Watch Video Done");
        var playerData = GameManager.Instance.PlayerDataManager;
        
    }

}


