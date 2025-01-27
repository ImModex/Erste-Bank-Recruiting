using System.Collections;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride.Erste_Bank.Scripts
{
    public class ErstePOIExtender : MonoBehaviour
    {
        private ErsteBankTask task;
        private SpatialPointOfInterest poi;
        private CapsuleCollider coll;
        private bool waitedLongEnough = false;
        private Coroutine waitingTask;
        
        void Start()
        {
            task = GetComponentInParent<ErsteBankTask>();
            poi = gameObject.GetComponent<SpatialPointOfInterest>();
            coll = gameObject.AddComponent<CapsuleCollider>();
            
            coll.height = 50;
            coll.radius = poi.textDisplayRadius;
            coll.isTrigger = true;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 30) return;
            waitingTask = StartCoroutine(nameof(WaitingTask));
            task.gameManager.loadingBarManager.AddWaitingBar(task.minimumTime);
        }

        private IEnumerator WaitingTask()
        {
            yield return new WaitForSeconds(task.minimumTime);
            waitedLongEnough = true;
            task.gameManager.loadingBarManager.RemoveWaitingBar();
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != 30) return;
            
            if (waitedLongEnough)
            {
                task.MinimumTimeController();
                
                Destroy(coll);
            }
            else StopCoroutine(waitingTask);
            
            task.gameManager.loadingBarManager.RemoveWaitingBar();
        }
    }
}
