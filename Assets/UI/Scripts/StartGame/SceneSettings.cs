using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject LosePanel;
    public GameObject menuLose;
    public GameObject menuRevival;
    public GameSoundManager GSM;

    public void Start()
    {
        GameObject monk = GameObject.Find("monkWithColider");
        GSM = monk.GetComponent<GameSoundManager>();
    }
    public void PauseButtonPessed()
    {
        GSM.Pause.TransitionTo(0.5f);

        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPressed()
    {
        GSM.Normal.TransitionTo(1.5f);

        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        GSM.Normal.TransitionTo(1.5f);

        GameManager.Instance.Restart();
    }
    //public void LoseButton()
    //{
    //    menuRevive = GameObject.Find("MenuRevive")
    //}
    public void ExitInMenu()
    {
        GSM.Normal.TransitionTo(1.5f);

        GameManager.Instance.Restart();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Revive()
    {
        menuRevival = GameObject.Find("MenuRevival");
        menuRevival.SetActive(false);
        GameManager.Instance.Revive();
        Time.timeScale = 1f;
    }
    public void ToLoseMenu()
    {
        menuRevival = GameObject.Find("MenuRevival");
        menuRevival.SetActive(false);
        GameManager.Instance.ResetGame();
    }
}
