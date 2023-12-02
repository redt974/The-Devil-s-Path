using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    //Affichage
    public TMP_Text timer;

    public float time ;
    public static float timestart;



  



    // Start is called before the first frame update
    void Start()
    {

        time = 0f;
       
    }



    // Update is called once per frame
    void Update()
    {
        time = Time.time - timestart;
        int minutes = Mathf.FloorToInt(time / 60);
        int secondes = Mathf.FloorToInt(time - minutes * 60);
        timer.text = System.String.Format("{0} m {1} s", minutes, secondes);


        
        



    }



    public void Test()
    {
        Debug.Log("Test");




    }


    

    public void Settimer()
    {


        timestart = Time.time;
    }


}
