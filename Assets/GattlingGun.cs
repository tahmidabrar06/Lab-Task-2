using UnityEngine;

public class GattlingGun : Weapon
{
    private GameObject barrel;

    void Start()
    {
        barrel = GameObject.Find("Barrel");
    }
    public override void HandleWeaponInput(bool pressedThisFrame,bool isHeld)
    {
        if (isHeld)
        {
            UseWeapon();
        }
    }

    protected override void UseWeapon()
    {
        Debug.Log("GattlingGun firing");
        AnimateGun();
    }

    void AnimateGun()
    {
        barrel.transform.Rotate(new Vector3(0,1,0) * 600 * Time.deltaTime);
    }
}