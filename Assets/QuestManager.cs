using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager instance;

        void Start()
        {
            instance = this;
            StartQuest(_quests[0]);
        }

        public List<ErsteBankQuest> _quests;
        private Dictionary<ErsteBankQuest, IQuestTask> _questTasks = new();

        public void AddQuest(ErsteBankQuest quest)
        {
            _quests.Add(quest);
        }

        public ErsteBankQuest GetQuestById(int id)
        {
            return _quests.FirstOrDefault(eq => eq.id == id);
        }

        public ErsteBankQuest GetQuestByName(string name)
        {
            return _quests.FirstOrDefault(eq => eq.name == name);
        }

        public void StartQuest(ErsteBankQuest quest)
        {
            // TODO: Check if there is a Spatial(!!!) Quest running, if not, start one
            
            StartCoroutine(AddTask(quest));
            StartCoroutine(ProgressAfterTime());
        }

        // DEBUG
        private IEnumerator ProgressAfterTime()
        {
            yield return new WaitForSeconds(10);
            ProgressQuest(_quests[0]);
        }

        private IEnumerator AddTask(ErsteBankQuest quest)
        {
            // TODO: Change to when quest is loaded 
            yield return new WaitForSeconds(1);
            
            var selectedTask = quest.tasks[0];
            var addedTask = SpatialBridge.questService.currentQuest.AddTask(selectedTask.name, selectedTask.type, selectedTask.progressSteps, selectedTask.taskMarkers);
            addedTask.Start();
            
            _questTasks.Add(quest, addedTask);
        }

        public void ProgressQuest(ErsteBankQuest quest)
        {
            if (!_questTasks.TryGetValue(quest, out var ersteTask)) return;
            
            var spatialTask = SpatialBridge.questService.currentQuest.GetTaskByID(ersteTask.id);

            if (++spatialTask.progress >= spatialTask.progressSteps)
            {
                spatialTask.Complete();
            }
        }
    }
}
