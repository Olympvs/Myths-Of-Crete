using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        public List<WeaponItem> weaponsInventory;

        private void Awake() 
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start() 
        {
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }
    }
}
