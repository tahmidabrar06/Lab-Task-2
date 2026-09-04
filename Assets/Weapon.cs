using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void HandleWeaponInput(
        bool pressedThisFrame,
        bool isHeld
    );

    protected abstract void UseWeapon();
}