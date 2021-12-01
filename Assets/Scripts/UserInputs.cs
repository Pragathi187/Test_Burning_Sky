using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputs : MonoBehaviour
{
    

    


   
    public void Resume()
    {
        
        Time.timeScale = 1f;
        
    }

    public void Pause()
    {
        
        Time.timeScale = 0f;
       
    }
}
