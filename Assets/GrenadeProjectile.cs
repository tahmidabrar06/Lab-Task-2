using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Grenade hit: " + collision.collider.name);

        Explode();
    }

    void Explode()
    {
        Debug.Log("BOOM");
        Destroy(gameObject);
    }
}
