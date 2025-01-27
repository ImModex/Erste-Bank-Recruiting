using System.ComponentModel;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride.Erste_Bank.Scripts
{
    public class ErsteBankTask : MonoBehaviour
    {
        [HideInInspector]
        public GameManagerScript gameManager;

        [TextArea(1, 1)] public string title;
        [TextArea(1, 5)] public string description;
        public float timeToComplete = 0;
        
        [Tooltip("The minimum time the player must be standing in the quest radius before it can be completed.")]
        public float minimumTime = 0;
        
        public bool startOnLoad = false;
        public bool completed = false;
        
        [Header("On Start")]
        public ErsteBankTaskEvents onStartEvents;
        
        [Header("On Failed")]
        public ErsteBankTaskEvents onFailedEvents;
        
        [Header("On Complete")]
        public ErsteBankTaskEvents onCompleteEvents;
        
        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            gameManager.tasks.Add(this);
            
            //onFailedEvents.resetTask = true;
            //onFailedEvents.resetTask = true;
            if(startOnLoad) StartTask();
        }

        public void StartTask()
        {
            gameManager.loadingBarManager.AddLoadingBar(this);
            gameManager.loadingBarManager.StartLoadingBar(this);
            
            onStartEvents.Invoke();
            
            onStartEvents.objectsToEnable.ForEach(obj =>
            {
                var interactable = obj.GetComponent<SpatialInteractable>();
                if (interactable == null) return;
                
                obj.SetActive(false);
            });
        }
        
        public void FailTask()
        {
            //gameManager.loadingBarManager.RemoveLoadingBar(this);
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
            gameManager.loadingBarManager.RemoveWaitingBar();
            completed = false;
            //var poi = gameObject.GetComponentInChildren<ErstePOIExtender>(true);
            //if(poi != null){ poi.ResetWait();} else {Debug.Log("Component not found");}
            if(startOnLoad) StartTask();
        }
        
        public void MinimumTimeController()
        {
            onStartEvents.objectsToEnable.ForEach(obj =>
            {
                var interactable = obj.GetComponent<SpatialInteractable>();
                if (interactable == null) return;
                
                obj.SetActive(true);
            });
            gameManager.loadingBarManager.RemoveWaitingBar();
        }
    }
}
