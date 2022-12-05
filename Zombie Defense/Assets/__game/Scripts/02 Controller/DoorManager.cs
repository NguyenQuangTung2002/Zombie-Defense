using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance;
    
    public List<GameObject> doors;
    public List<DoorLeaf> doorsLeaf;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            doorsLeaf.Add( doors[i].GetComponentInChildren<DoorLeaf>());
        }
    }

    public int PaidRepair()
    {
        int total = 0;
        for (int i = 0; i < doorsLeaf.Count; i++)
        {
            if (doorsLeaf[i].costRepair > 0)
            {
                total += doorsLeaf[i].costRepair;
            }
        }

        return total;
    } 

    public void RepairDoors()
    {
        Wallet.Instance.PaidCoins(PaidRepair());
        
        for (int i = 0; i < doorsLeaf.Count; i++)
        {
            if (doorsLeaf[i].costRepair>0)
            {
                doorsLeaf[i].Repair();
            }
        }
    }
}
