using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float m_timeInMinute = 5.0f;
    [SerializeField] private float m_timeInSeconds = 0;
    [SerializeField] private Score[] m_countryScores = new Score[3];
    public InGameMenu m_menu = null;
    public GameObject m_timerText = null;
    private TextMeshProUGUI m_timer = null;
    
    private void Start()
    {
        if (m_timerText.GetComponent<TextMeshProUGUI>())
            m_timer = m_timerText.GetComponent<TextMeshProUGUI>();
        
        m_timeInSeconds = m_timeInMinute * 60.0f;
        StartCoroutine(nameof(StartTimer));
    }

    private void TimesUp()
    {
        int score = CalculateScore();

        if (m_menu)
            m_menu.OpenNextLevel(score);
    }

    private int CalculateScore()
    {
        int score = 0;

        foreach (var countryScore in m_countryScores)
        {
            if (countryScore.GetScore() >= countryScore.GetObjective())
                ++score;
        }
        
        return score;
    }

    IEnumerator StartTimer()
    {
        WaitForSecondsRealtime timeToWait = new WaitForSecondsRealtime(1);
        m_timeInSeconds -= 1.0f;
        UpdateUI();
        yield return timeToWait;
        
        if (m_timeInSeconds > 0)
            yield return StartCoroutine(nameof(StartTimer));
        else
        {
            TimesUp();
            yield return null;
        }
    }

    private void UpdateUI()
    {
        string timerString = m_timeInSeconds.ToString();

        if (m_timer)
            m_timer.text = timerString;
    }
}
