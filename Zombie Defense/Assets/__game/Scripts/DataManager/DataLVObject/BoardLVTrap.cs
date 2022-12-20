using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLVTrap/*: BoardLVObject<LevelTrap>*/
{
   private static BoardLVTrap instance;
   public static BoardLVTrap Instance => instance;
   
   private LevelType levelType = LevelType.Trap;
   /*[SerializeField] public override List<LevelTrap> objects { get; set; } */

   private void Awake()
   {
      instance = this;
   }
}

