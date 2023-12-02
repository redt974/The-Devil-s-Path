using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Rigidbody rigi;
    public float explosionRadius;
    public float explosionForce;
    public float vitesse;
   

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Destroy(gameObject, 1);
    }

    private void FixedUpdate()
    {
        rigi.velocity = transform.forward * vitesse;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] result = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in result)
        {
            if (collider.gameObject.CompareTag("Ennemi"))
            {
                Destroy(collider.gameObject);
            }                
        }
        Destroy(gameObject);
    }

}