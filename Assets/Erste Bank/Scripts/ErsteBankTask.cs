using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpatialSys.UnitySDK;
using UnityEngine;
using UnityEngine.Events;

namespace SpatialSys.Samples.InputOverride
{
    public class ErsteBankTask : MonoBehaviour
    {
        [TextArea(1, 1)] public string title;
        [TextArea(1, 5)] public string description;
        public float timeToComplete = 0;
        
        public bool startOnLoad = false;
        public bool completed = false;
        
        [Header("On Start")]
        public ErsteBankTaskEvents onStartEvents;
        
        [Header("On Failed")]
        public ErsteBankTaskEvents onFailedEvents;
        
        [Header("On Complete")]
        public ErsteBankTaskEvents onCompleteEvents;
        
        private GameManagerScript gameManager;
        
        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            gameManager.tasks.Add(this);
            
            if(startOnLoad) StartTask();
        }

        public void StartTask()
        {
            gameManager.loadingBarManager.AddLoadingBar(this);
            gameManager.loadingBarManager.StartLoadingBar(this);
            
            onStartEvents.Invoke();
        }
        
        public void FailTask()
        {
            gameManager.loadingBarManager.RemoveLoadingBar(this);
            gameManager.ResetTasks();
            
            onFailedEvents.Invoke();
        }
        
        public void CompleteTask()
        {
            gameManager.loadingBarManager.RemoveLoadingBar(this);
            
            onCompleteEvents.Invoke();
            completed = true;
        }

        public void ResetTask()
        {
            gameManager.loadingBarManager.RemoveLoadingBar(this);
            completed = false;
            
            if(startOnLoad) StartTask();
        }
    }
}
