using System;
using System.Collections;
using System.Collections.Generic;
using SpatialSys.UnitySDK;
using UnityEngine;

namespace SpatialSys.Samples.InputOverride
{
    [Serializable]
    public class ErsteBankQuest : MonoBehaviour
    {
        public int id;
        public string name;
        public List<SpatialQuest.Task> tasks = new();
        public int currentTask = 0;
    }
}
