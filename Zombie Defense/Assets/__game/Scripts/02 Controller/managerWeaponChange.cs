using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class managerWeaponChange : MonoBehaviour
{
    public AnimatorOverrideController[] overrideAnimator;
    public static managerWeaponChange Instance;
    public List<Weapon> weaponsPrefab;
    public List<Weapon> weapons;
    public Transform pivotR;
    private int indexPreviousWeapon;
    

    private void Awake()
    {
        Instance = this;
        foreach (var iWeapon in weaponsPrefab)
        {
            var tmp=Instantiate(iWeapon,pivotR);
            tmp.gameObject.SetActive(false);
            weapons.Add(tmp);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        int defaultWeaponIndex = 2;
        ChangeWeapon(defaultWeaponIndex);
    }

    public void ChangeWeapon(int weaponIndex)
    {
        if (weaponIndex != indexPreviousWeapon || indexPreviousWeapon == null)
        {
            weapons[indexPreviousWeapon].gameObject.SetActive(false);
            
            Weapon tempWeapon = weapons[weaponIndex];
            tempWeapon.gameObject.SetActive(true);
            CharController.Instance.ChangeWeapon(tempWeapon);

            indexPreviousWeapon = weaponIndex;
            
        }
        
        // Change Anim Character
        CharController.Instance.ChangeCharAnim( overrideAnimator[weaponIndex]);
    }
    
    public void ButtonChangeWeapon()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        int tempBtnIndex = tempBtn.transform.GetSiblingIndex();
        
        ChangeWeapon(tempBtnIndex);
        
    }
    
    
}
