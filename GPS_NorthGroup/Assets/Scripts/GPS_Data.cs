using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS_Data : MonoBehaviour {

    public Text latitud, longitud, altitud, hAcurracy, timestamp;
    //public GameObject pointData;
    //public GameObject textTemplate;
    public Font m_Font;
    public AudioSource audioData;
    private Vector3 _p;

    private void Start()
    {
        StartCoroutine(StartLocationServices());
    }

    private IEnumerator StartLocationServices()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start(1.0f,1.0f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }

        while (Input.location.status == LocationServiceStatus.Running)
        {
            //while (true)
            //{          
            yield return new WaitForSeconds(1.0f);
            audioData.Play();
            Do();

            //}
        }

        //yield break;
    }

    void Do()
    {
        latitud.text = "Latitud: " + Input.location.lastData.latitude.ToString();
        longitud.text = "Longitude: " + Input.location.lastData.longitude.ToString();
        altitud.text = "Altitude: " + Input.location.lastData.altitude.ToString();
        hAcurracy.text = List_Points.list.Count.ToString();
        timestamp.text = Input.location.status.ToString();

        _p = new Vector3(Input.location.lastData.latitude, Input.location.lastData.longitude,
            Input.location.lastData.altitude);

        if (!List_Points.list.Contains(_p))
        {
            List_Points.AddToList(_p);
            audioData.Play();
        }
    }

}
