﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Brick : MonoBehaviour
{
    
    [Header("Sound")]
    private AudioSource audioSource;
    public AudioClip notenoughMoneySound;
    public AudioClip enoughMoneySound;

    [Header("Color")]
    public Color placeColor;
    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject currentBlackAnt;
    [HideInInspector]
    public BlackAntBlueprint blackAntBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color StartColor;
    [SerializeField] private Vector3 posOffset;

    Building building;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        building = Building.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }

    void BuildAnt(BlackAntBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough Money to Build That!!!");
            audioSource.clip = notenoughMoneySound;
            audioSource.Play();
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        audioSource.clip = enoughMoneySound;
        audioSource.Play();
        GameObject blackAnt = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currentBlackAnt = blackAnt;
        blackAntBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(building.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret Built!");
    }

   
    public void UpgradeAnt()
    {
        if (PlayerStats.Money < blackAntBlueprint.upgradeCost)
        {
            Debug.Log("Not Enough Money to Upgrade That!!!");
            audioSource.clip = notenoughMoneySound;
            audioSource.Play();
            return;
        }

        PlayerStats.Money -= blackAntBlueprint.upgradeCost;

        //Destroy the old turret 
        Destroy(currentBlackAnt);

        //Build the new one
        audioSource.clip = enoughMoneySound;
        audioSource.Play();
        GameObject blackAnt = (GameObject)Instantiate(blackAntBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        currentBlackAnt = blackAnt;

        GameObject effect = (GameObject)Instantiate(building.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret Upgrade!");
        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += blackAntBlueprint.SellAmount();
        //Spawn Effect

        Destroy(currentBlackAnt);
        blackAntBlueprint = null;
        //audioSource.
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (currentBlackAnt != null)
        {
            building.SelectBrick(this);
            return;
        }

        if (!building.CanBuild)
        {
            return;
        }

        //Build a turret
        BuildAnt(building.GetBlackAntToBuild());
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }    

        if (!building.CanBuild)
        {
            return;
        }

        if (building.HasMoney)
        {
            rend.material.color = placeColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }


}
