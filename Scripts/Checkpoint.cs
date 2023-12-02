using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Checkpoint : MonoBehaviour
{
    public bool perso_pass�e = false;
    public Vector3 posPerso;
    public int num_scene;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            perso_pass�e = true;
        }
    }
}
