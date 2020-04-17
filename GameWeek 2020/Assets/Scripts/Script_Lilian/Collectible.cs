using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string name;
    public Sprite icon;
    [SerializeField] private AudioClip m_dropAudio;

    void OnCollisionEnter(Collision p_col)
    {
        if (!p_col.gameObject.CompareTag("Player"))
            AudioManager.instance.PlaySoundOnce(m_dropAudio);
    }
}
