using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_Screen : MonoBehaviour {
	void Update ()
    {
        //If scan can be passed by just touching the screen.
        Touch touch = Input.GetTouch(0);
        if(touch.position.x > 0)
        {
            //Scene manager loader: Load the scene by an index or name.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       
        }    
    }
}
