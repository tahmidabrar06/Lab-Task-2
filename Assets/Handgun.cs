using UnityEngine;

public class Handgun : Weapon
{
    [SerializeField] private float range = 100f;
    [SerializeField] private float impactForce = 0.5f;
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
        Transform camTransform = Camera.main.transform;
        Ray ray = new Ray(camTransform.position, camTransform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.Log("Gun hit" + hit.collider.name);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(camTransform.forward * impactForce, hit.point, ForceMode.Impulse);
            }
        }
        Debug.DrawRay(camTransform.position, camTransform.forward * range,Color.red,1f);
    }
}