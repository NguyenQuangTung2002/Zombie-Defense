using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyReward", menuName = "Data/DailyReward")]
public class DailyRewardData : SerializedScriptableObject
{
    public List<RewardDay> Days;
}
public class RewardDay
{
    public RewardType Type;
    public int Amount;
}