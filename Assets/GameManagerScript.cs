using System.Collections;
using System.Collections.Generic;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class GameManagerScript : MonoBehaviour
    {

        public GameObject timeBarEmail;
        public GameObject timeBarMeeting;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void startReadEmailTimer()
        {
           timeBarEmail.SetActive(true);
        }

        public void stopEmailTimer()
        {
            timeBarEmail.SetActive(false);
        }

        public void startMeetingTimer()
        {
            timeBarMeeting.SetActive(true);
        }

        public void stopMeetingTimer()
        {
            timeBarMeeting.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
