using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader {
    
    public enum Scene {
        MainHome,
        SampleScene,
        Loading,
        OverviewHouse,
        Kitchen,
        Laboratory,
        Storage,
    }
    private static Action onLoaderCallback;

    public static void Load(Scene scene) {
        // Set the loader callback action to load target scene
        onLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };

        // Loading the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback() {
        // Triggered after the first Update which lets the screen refresh
        // Execute the loader callback action which will load the target scene
        if (onLoaderCallback != null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
