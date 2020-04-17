using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] private Inventory m_inventory = null;
    [SerializeField] private AudioClip m_pickupSound;
    [SerializeField] private GameObject m_collectibleItem = null;
    public void Initialize(Inventory p_inventory)
    {
        m_inventory = p_inventory;
        m_pickupSound = GetComponent<PlayerController>().m_pickupSound;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && m_collectibleItem)
        {
            if (m_inventory.AddNewItem(m_collectibleItem))
            {
                m_collectibleItem.gameObject.SetActive(false);
                m_collectibleItem = null;
                AudioManager.instance.PlaySoundOnce(m_pickupSound);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Collectible>())
            return;
            
        m_collectibleItem = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Collectible>())
            return;
        
        m_collectibleItem = null;
    }
}
