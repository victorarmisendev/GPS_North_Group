using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Action : MonoBehaviour {

	public void ChangeScene(string name)
    {      
        SceneManager.LoadScene(name);
    }

    public void ChangeByIdx(int idx)
    {
        SceneManager.LoadScene(idx);
    }

}
