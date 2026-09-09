using System;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask explositonLayer;
    [SerializeField]
    private float explosionRadius = 7;
    [SerializeField]
    private float explosionPower = 200;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Grenade hit: " + collision.collider.name);

        Explode();
    }

    void Explode()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(gameObject.transform.position, explosionRadius, explositonLayer);
        
        foreach(Collider collider in collidersInRange)
        {
            collider.attachedRigidbody.AddExplosionForce(explosionPower, transform.position, explosionRadius, 1, ForceMode.Force);
        }
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
