using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private string m_sceneToLoad;
    [SerializeField]
    private string m_nextLevel;
    [SerializeField]
    private GameObject m_soundPanel;
    [SerializeField]
    private GameObject m_mainPanel;
    [SerializeField]
    private GameObject m_nextLevelPanel;
    
    void Start()
    {
        m_mainPanel.SetActive(false);
        m_soundPanel.SetActive(false);
        m_nextLevelPanel.SetActive(false);
    }

    public void OpenSoundPanel()
    {
        m_mainPanel.SetActive(false);
        m_soundPanel.SetActive(true);
    }

    public void CloseSoundPanel()
    {
        m_mainPanel.SetActive(true);
        m_soundPanel.SetActive(false);
    }

    public void CloseAllPanels()
    {
        m_mainPanel.SetActive(false);
        m_soundPanel.SetActive(false);
    }
    
    public void ToggleMainPanel()
    {
        m_mainPanel.SetActive(!m_mainPanel.activeSelf);
        m_soundPanel.SetActive(false);
    }

    public void OpenNextLevel()
    {
        m_nextLevelPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainPanel();
            if (m_mainPanel.activeSelf)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeMusicVolume(float p_value)
    {
        AudioManager instance = AudioManager.instance;
        instance.SetVolume(instance.m_ambientMusicAudioSource, p_value);
    }

    public void ChangeFXVolume(float p_value)
    {
        AudioManager instance = AudioManager.instance;
        instance.SetVolume(instance.m_oneShotAudioSource, p_value);
        instance.SetVolume(instance.m_loopAudioSource, p_value);
    }

    public void ResumeGame()
    {
        CloseAllPanels();
        Time.timeScale = 1;
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(m_nextLevel);
    }
}
