using UnityEngine;

public class GattlingGun : Weapon
{
    private GameObject barrel;
    [SerializeField] private float range = 100f;
    [SerializeField] private float impactForce = 7;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private float accuracy = 0.05f;

    private float timer = 0f;

    void Start()
    {
        barrel = GameObject.Find("Barrel");
    }
    public override void HandleWeaponInput(bool pressedThisFrame, bool isHeld, bool releasedThisFrame)
    {
        if (isHeld)
        {
            AnimateGun();
            timer += Time.deltaTime;
            if(timer >= fireRate)
            {
                UseWeapon();
                timer = 0;
            }
        }
    }

    protected override void UseWeapon()
    {
        Transform camTransform = Camera.main.transform;

        //random offset
        float randomX = Random.Range(-accuracy, accuracy);
        float randomY = Random.Range(-accuracy, accuracy);
        Vector3 shootDirection = camTransform.forward + camTransform.right * randomX + camTransform.up * randomY;
        shootDirection.Normalize();

        Ray ray = new Ray(camTransform.position, shootDirection);

        if(Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.Log("Gun hit" + hit.collider.name);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(camTransform.forward * impactForce, hit.point, ForceMode.Impulse);
            }
        }
        Debug.DrawRay(camTransform.position,shootDirection * range,Color.red,1f);
    }

    void AnimateGun()
    {
        barrel.transform.Rotate(new Vector3(0,1,0) * (50/fireRate) * Time.deltaTime);
    }
}