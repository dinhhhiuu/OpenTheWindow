using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTriggerWithDoor : MonoBehaviour {
    public Loader.Scene targetScene;
    private string doorID;
    [SerializeField] private GameObject doorObject;
    private Animator doorAnimator;

    private void Start() {
        doorID = gameObject.name;
        doorAnimator = doorObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            PlayerSpawnData.lastDoorID = doorID;
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor() {
        doorAnimator.SetBool("isOpenDoor", true);
        yield return new WaitForSeconds(0.7f); 
        Loader.Load(targetScene);
    }
}
