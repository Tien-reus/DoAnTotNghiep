using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;

    [SerializeField] private AudioSource _handtake;


    public void EnableWeapon()
    {

        weaponLogic.SetActive(true);

        _handtake.Play();

    }
    public void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }

}
