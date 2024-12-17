using System.Collections;
using System.Collections.Generic;
using SpatialSys.Samples.InputOverride.Erste_Bank.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace SpatialSys.Samples.InputOverride
{
    [System.Serializable]
    public class ErsteBankTaskEvents
    {
        public UnityEvent events;
        
        public List<GameObject> objectsToEnable;
        public List<GameObject> objectsToDisable;

        public List<ErsteBankTask> tasksToStart;

        public bool endAllTasks;
        public bool resetTask;

        public void Invoke()
        {
            events.Invoke();
            
            objectsToEnable.ForEach(obj => obj.SetActive(true));
            objectsToDisable.ForEach(obj => obj.SetActive(false));
            
            tasksToStart.ForEach(task => task.StartTask());
        }
    }
}
