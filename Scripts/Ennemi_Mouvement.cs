using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ennemi_Mouvement : MonoBehaviour
{
    public Transform target;
    public Transform visuelPersonnage;
    private Rigidbody rigi;
    public float vitesse;
    public AnimationManager animationManager;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animationManager.Move(rigi.velocity.magnitude);
        if (rigi.velocity.magnitude > .1f && Mathf.Abs(rigi.velocity.y) < .1f)
        {
            visuelPersonnage.forward = rigi.velocity;
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        dir.y = 0;
        rigi.velocity = dir.normalized * vitesse;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            animationManager.Attaquer();
            collision.gameObject.GetComponent<Deplacement1>().pts_de_vies -= 10;
        }
    }
}
