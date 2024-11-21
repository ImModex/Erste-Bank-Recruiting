using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class ElevatorDoors : MonoBehaviour
    {
        [SerializeField] GameObject DoorL;
        [SerializeField] GameObject DoorR;
        bool open = false;

    public void Open()
    {
        StartCoroutine("OpenTimer");
    }

    IEnumerator OpenTimer()
    {
        open = true;
        yield return new WaitForSeconds(2);
        open = false;
    }

    public void Update()
    {
        if(open)
        {
            DoorL.transform.Translate(Vector3.right * Time.deltaTime);
            DoorR.transform.Translate(Vector3.left * Time.deltaTime);
        }
    }
    }

    
    
}
