using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class LoadingBarManager : MonoBehaviour
    {
        private Dictionary<ErsteBankTask, GameObject> loadingBars = new();
        public GameObject loadingBarPrefab;

        public GameObject canvas;
        public float yOffset = 50;
        
        public void AddLoadingBar(ErsteBankTask task)
        {
            var loadingBar = Instantiate(loadingBarPrefab, canvas.transform);
            loadingBar.SetActive(false);
            
            var loadingBarScript = loadingBar.GetComponentInChildren<loadingbar>();
            loadingBarScript.textComp.text = task.title;
            loadingBarScript.maxTime = task.timeToComplete;
            loadingBarScript.task = task;
            
            loadingBars.Add(task, loadingBar);
        }
        
        public void StartLoadingBar(ErsteBankTask task)
        {
            loadingBars[task].SetActive(true);
        }
        
        public void PauseLoadingBar(ErsteBankTask task)
        {
            var loadingBarScript = loadingBars[task].GetComponentInChildren<loadingbar>();
            loadingBarScript.pause = true;
        }
        
        public void ResumeLoadingBar(ErsteBankTask task)
        {
            var loadingBarScript = loadingBars[task].GetComponentInChildren<loadingbar>();
            loadingBarScript.pause = false;
        }
        
        public void RemoveLoadingBar(ErsteBankTask task)
        {
            loadingBars.Remove(task, out var bar);
            Destroy(bar);
        }
    }
}
