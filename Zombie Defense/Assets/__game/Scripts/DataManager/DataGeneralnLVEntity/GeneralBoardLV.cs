
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralBoardLV", menuName = "BoardLV/GeneralBoard")]
public class GeneralBoardLV: ScriptableObject
{
  [SerializeField] public List<LevelCharSpeed> CharSpeeds;
  [SerializeField] public List<LevelCharHealh> CharHealhs;
  [SerializeField] public List<LevelTrap> Traps;
  [SerializeField] public List<LevelSentryTower> SentryTower;
  [SerializeField] public List<LevelDoor> Doors;
}