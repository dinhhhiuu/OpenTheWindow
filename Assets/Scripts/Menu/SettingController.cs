using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour {
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject winPanel;

    private static bool isTurnSound = true;
    [SerializeField] private Loader.Scene targetScene;

    private void Update() {
        Winning();
    }

    public void SetPanel() {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void ClosePanel() {
        settingPanel.SetActive(false);
    }

    public void TurnSound() {
        if (isTurnSound) {
            line.SetActive(true);
            AudioManager.Instance.PauseBackGroundMusic();
            isTurnSound = false;
        } else {
            line.SetActive(false);
            AudioManager.Instance.PlayBackGroundMusic();
            isTurnSound = true;
        }
    }

    public void ResetGame() {
        DestroyPersistentObjects();
        Loader.Load(targetScene);
    }

    private void DestroyPersistentObjects() {
        if (PlayerManager.Instance != null)
            Destroy(PlayerManager.Instance.gameObject);

        if (ItemSaveManager.Instance != null)
            Destroy(ItemSaveManager.Instance.gameObject);
        
        if (ItemAssets.Instance != null)
            Destroy(ItemAssets.Instance.gameObject);

        if (WindowSaveManager.Instance != null)
            Destroy(WindowSaveManager.Instance.gameObject);

        if (WindowAssets.Instance != null)
            Destroy(WindowAssets.Instance.gameObject);

        if (PersistCanvas.Instance != null)
            Destroy(PersistCanvas.Instance.gameObject);

        if (KeyManager.Instance != null)
            Destroy(KeyManager.Instance.gameObject);

        if (AudioManager.Instance != null)
            Destroy(AudioManager.Instance.gameObject);

        if (PlayerSpawnData.Instance != null)
            Destroy(PlayerSpawnData.Instance.gameObject);

        if (player.Instance != null)
            Destroy(player.Instance.gameObject);
    }

    private void Winning() {
        if (WindowSaveManager.Instance.GetCollectedWindowCount() == 5) {
            winPanel.SetActive(true);
        }
    }
}
