using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SentinelLVBoard", menuName = "BoardLV/SentinelLVBoardd")]
public class SentinelLVBoard : SerializedScriptableObject
{
   public List<LevelSentinel> sentinel;
}

public class LevelSentinel
{
   public int damage;
   public int coinUpgrade;
   public int coinUnlock;
}