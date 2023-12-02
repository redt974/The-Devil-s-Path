using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi_Spawner : MonoBehaviour
{
    public int nb_zombies = 30;
    [SerializeField] private Ennemi_Mouvement ennemi;
    [SerializeField] private Transform target;
    [SerializeField] private float timer;

    private float t;

    // Update is called once per frame
    void Update()
    {
        if (t < 0)
        {
            if (nb_zombies > 0)
            {
                var e = Instantiate(ennemi);
                e.transform.position = new Vector3(Random.Range(9, 0), 0, Random.Range(0, 9));
                e.target = target;
                nb_zombies -= 1;
                t = timer;
            }
        }
        t -= Time.deltaTime;
    }
}
