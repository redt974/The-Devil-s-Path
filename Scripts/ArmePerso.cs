using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmePerso : MonoBehaviour
{
    public Missile missile;
    public GameObject perso;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Shoot();
    }

    private void Shoot()
    {
        Missile m = Instantiate(missile);
        m.transform.position = gameObject.transform.position;
        m.transform.forward = transform.forward;

        Destroy(m, 5f);
    }
}
