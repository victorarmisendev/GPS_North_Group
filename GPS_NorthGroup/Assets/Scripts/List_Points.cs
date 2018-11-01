using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class List_Points : MonoBehaviour {

    public static List<Vector3> list; // Contenedor para el alojamiento de los puntos del GPS
    public Text[] _text;
    public GameObject textTemplate;
    public GameObject CANVAS;

    private void Start()
    {
        list = new List<Vector3>();
        _text = new Text[1];     
    }

    private void Update()
    {
        Array.Resize(ref _text, list.Count);
        //Debug.Log(_text.Length);
        Print(list);
    }

    void Print(List<Vector3> list)
    {
        for (int i = 0; i < _text.Length; i++)
        {
            GameObject newText = Instantiate(textTemplate) as GameObject;
            newText.GetComponent<Text>().text = "Point " + i + list[i].ToString();
            newText.GetComponent<Text>().fontSize = 35;
            newText.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
            newText.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            newText.transform.parent = CANVAS.transform;
            newText.transform.position = new Vector3(0, i * 40, 0);
            newText.transform.position += CANVAS.transform.position;
            Debug.Log(i);
        }
    }

    public static void AddToList(Vector3 point)
    {
        list.Add(point);
    }

}
