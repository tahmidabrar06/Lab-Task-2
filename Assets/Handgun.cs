using UnityEngine;

public class Handgun : Weapon
{
    public override void HandleWeaponInput(
        bool pressedThisFrame,
        bool isHeld
    )
    {
        if (pressedThisFrame)
        {
            UseWeapon();
        }
    }

    protected override void UseWeapon()
    {
        Debug.Log("Handgun fired");
    }
}