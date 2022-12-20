using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharData 
{
   public int lvHealth { get; set; }
   public int lvSpeed { get; set; }
   public int indexDrone { get; set; }
   public int indexSkin { get; set; }
   public int indexWeapon { get; set; }
}

[Serializable]
public class CharFormData
{
   public int lvHealth;
   public int lvSpeed;
   public int indexDrone;
   public int indexSkin;
   public int indexWeapon;
}

public class ListChar
{
   public List<CharFormData> chars;
}
