using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    public void SetTextFunc(string text)
    {
        GetComponent<Text>().text = text;
    }

}
