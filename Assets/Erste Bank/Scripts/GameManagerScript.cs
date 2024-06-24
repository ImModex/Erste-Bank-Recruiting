using System.Collections;
using System.Collections.Generic;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class GameManagerScript : MonoBehaviour
    {
        public LoadingBarManager loadingBarManager;
        public List<ErsteBankTask> tasks;

        public void ResetTasks()
        {
            // Disable all interactables and POIs
            var questsObject = GameObject.Find("Quests");
            
            foreach (var interactable in questsObject.transform.GetComponentsInChildren<SpatialInteractable>())
            {
                interactable.gameObject.SetActive(false);
            }
            
            foreach (var poi in questsObject.transform.GetComponentsInChildren<SpatialPointOfInterest>())
            {
                poi.gameObject.SetActive(false);
            }
            
            // Reset all tasks, this will re-enable the interactables and POIs depending on which tasks are set to start on load
            tasks.ForEach(task => task.ResetTask());
        }
    }
}
