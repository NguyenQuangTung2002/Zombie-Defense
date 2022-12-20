using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "DataShopItem", menuName = "ScriptableObjects/Data Shop Item", order = 1)]
public class DataShopItem : SerializedScriptableObject
{
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MaxScrollViewHeight = 400, MinScrollViewHeight = 200)]
    public List<DataItem> listDataShopWeapon;
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MaxScrollViewHeight = 400, MinScrollViewHeight = 200)]
    public List<DataItem> listDataShopSkins;
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MaxScrollViewHeight = 400, MinScrollViewHeight = 200)]
    public List<DataItem> listDataShopDrone;
}

public class DataItem
{
    public int idItem;
    public TypeUnlockSkin typeUnlock;
    public int numberVideoUnlock;
    public int numberCoinUnlock;
    public int levelUnlock;

}