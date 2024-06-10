using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class GameManagerScript : MonoBehaviour
    {

        public GameObject timeBar;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void startTimer()
        {
           timeBar.SetActive(true);
        }

        public void stopTimer()
        {
            timeBar.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
