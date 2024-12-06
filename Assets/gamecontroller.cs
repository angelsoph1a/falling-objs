using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{

    [SerializeField] private playercontroller playerController;
    public Canvas GameOverCanvas;
    public TMP_Text TimerText;

    private void Awake()
    {
        if(playerController != null)
        {
            playerController.playerDied += whenPlayerDies;
        }

        if (GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }
    void whenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);
        musicmanager.pausebg();
        TimerText.text = "You Lasted: " + Math.Round(Time.timeSinceLevelLoad, 2) + " seconds";

        if (playerController != null)
        {
            playerController.playerDied -= whenPlayerDies;
        }
    }

    public void retryClicked()
    {
        musicmanager.playbg(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
