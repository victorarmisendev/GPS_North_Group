using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Screen : MonoBehaviour {

    public Text altitude;

    void Update () {

        Touch touch = Input.GetTouch(0);
        altitude.text = "Altitude is equal to: " + touch.position;

    }
}
