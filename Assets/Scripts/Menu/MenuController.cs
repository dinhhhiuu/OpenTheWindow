using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public Loader.Scene targetScene;
    public GameObject infoPanel;

    public void StartGame() {
        Loader.Load(targetScene);
    }

    public void Info() {
        infoPanel.SetActive(true);
    }   

    public void ClosePanel() {
        infoPanel.SetActive(false);
    }
}
