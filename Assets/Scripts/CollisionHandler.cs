using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly unit");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadScene();
                break;
                
        }

        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

        void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
