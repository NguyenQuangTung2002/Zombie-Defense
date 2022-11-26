using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TrapCtrl : EntityScene
{

    [SerializeField] private Trap trap;
    [SerializeField] private GameObject floor;
    [SerializeField] private Button btnPopup;
    
    void Init()
    {
        trap.damage = 20;
        //cost = 50;
    }
    void Start()
    {
        Init();
        GetComponentInChildren<AttackRadius>().attackDelay = 1.3f;
        GetComponentInChildren<AttackRadius>().timeLoadDelay = 4f;
        trap.timeToLoad = GetComponentInChildren<AttackRadius>().timeLoadDelay;
        trap.circle.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && floor.activeSelf)
        {
            btnPopup.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && floor.activeSelf)
        {
            btnPopup.gameObject.SetActive(false);
        }
    }
    


}
