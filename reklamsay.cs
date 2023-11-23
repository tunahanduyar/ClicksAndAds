using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reklamsay : MonoBehaviour

{

    
    int reklamciksinmi;
    public GameObject reklamkontrol;


    void Start()
    { 



        if (PlayerPrefs.HasKey("reklamciksinmi"))
        {

            reklamciksinmi = PlayerPrefs.GetInt("reklamciksinmi");

            reklamciksinmi += 1;
            PlayerPrefs.SetInt("reklamciksinmi", reklamciksinmi);

        }

        else

        {

            PlayerPrefs.SetInt("reklamciksinmi", 0);
           
        }



 

        if (reklamciksinmi >= 3)

        {
            reklamkontrol.SetActive(true);
        }



    }

   

}
