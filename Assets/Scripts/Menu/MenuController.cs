using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public Loader.Scene targetScene;

    public void StartGame() {
        Loader.Load(targetScene);
    }
}
