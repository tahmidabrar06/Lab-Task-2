using System;
using UnityEngine;

public class Grenade : Weapon
{
    [SerializeField]
    private GameObject grenadePrefab;
    [SerializeField]
    private float maxThrowPower;
    [SerializeField]
    private float throwPower;

    public override void HandleWeaponInput(bool pressedThisFrame, bool isHeld, bool releasedThisFrame)
    {
        if (pressedThisFrame)
        {
            throwPower = 0.5f;
        }
        if (isHeld)
        {
            throwPower += Time.deltaTime;
            if(throwPower >= maxThrowPower)
            {
                throwPower = maxThrowPower;
            }
        }
        if (releasedThisFrame)
        {
            UseWeapon();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().unequipWeapon();
        }
    }

    protected override void UseWeapon()
    {
        GameObject grenade = Instantiate(grenadePrefab);
        Transform camTransform = Camera.main.transform;
        grenade.transform.position = camTransform.position + camTransform.forward * 0.6f;
        grenade.GetComponent<Rigidbody>().AddForce(camTransform.forward * throwPower * 10, ForceMode.Impulse);
        throwPower = 0;
    }
}
