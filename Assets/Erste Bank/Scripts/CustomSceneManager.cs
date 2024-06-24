using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spatial: Class that handles scene restarts. Spatial only supports one scene, so we create a 'prefab' out of the entire scene
/// we want to reload and then instantiate it when we want to restart the scene.
/// </summary>

[DefaultExecutionOrder(-1000)]
public class CustomSceneManager : MonoBehaviour
{
    public GameObject activeScene;
    private GameObject _sceneObjectPrefab;
    private static CustomSceneManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        activeScene.SetActive(false);

        // Save a copy of the scene.object
        _sceneObjectPrefab = Instantiate(activeScene);

        activeScene.SetActive(true);
    }

    public static void Restart()
    {
        if (_instance == null)
        {
            Debug.LogError("Scene instance is null");
            return;
        }

        Destroy(_instance.activeScene);
        _instance.activeScene = Instantiate(_instance._sceneObjectPrefab);
        _instance.activeScene.SetActive(true);
    }
}
