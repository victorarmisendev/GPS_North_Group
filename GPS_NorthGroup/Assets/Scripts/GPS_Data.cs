using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS_Data : MonoBehaviour {

    public Text latitud, longitud, altitud, hAcurracy, timestamp;

    private void Update()
    {
        //StartCoroutine(Search());

        Input.location.Start();

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("FAILED");
            
        }
        else
        {
            latitud.text = "Latitud: " + Input.location.lastData.latitude.ToString();
            longitud.text = "Longitude: " + Input.location.lastData.longitude.ToString();
            altitud.text = "Altitude: " + Input.location.lastData.altitude.ToString();
            hAcurracy.text = "Horizontal acurracy: " + Input.location.lastData.horizontalAccuracy;
            timestamp.text = "TimeStamp: " + Input.location.lastData.timestamp;

            Points point = new Points();

            point.point = new Vector3(Input.location.lastData.latitude, Input.location.lastData.longitude,
                Input.location.lastData.altitude);

            List_Points.list.Add(point);

        }

        Input.location.Stop();

    }

    IEnumerator Search()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();       

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
        
       

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}
