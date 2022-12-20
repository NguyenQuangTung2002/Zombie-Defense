using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoardLVObject<T> : SerializedScriptableObject
    where T : LevelData
{

    private LevelType levelType;
    public LevelType LevelType { get => levelType; set => levelType = value; }
    public virtual List<T> objects { get; set; }

}

