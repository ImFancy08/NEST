﻿using UnityEngine;

public class Building : MonoBehaviour
{
    public static Building instance;
    public GameObject normalBAnt;
    public GameObject aoeBAnt;
    public GameObject slowBAnt;

    public GameObject buildEffect;

    private BlackAntBlueprint blackAntToBuild;

    public bool CanBuild { get { return blackAntToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= blackAntToBuild.cost; } }

    private Brick selectedBrick;
    public BrickUI brickUI;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Building is in the scene");
            return;
        }
        instance = this;
    }


    public void SelectBrick(Brick brick)
    {
        if (selectedBrick == brick)
        {
            DeselectBrick();        
        }

        selectedBrick = brick;
        blackAntToBuild = null;
        brickUI.SetTarget(brick);
    }

    public void DeselectBrick()
    {
        selectedBrick = null;
        brickUI.Hide();
    }

    public void SelectBlackAntToBuild(BlackAntBlueprint blackAnt)
    {
        blackAntToBuild = blackAnt;
        DeselectBrick();
    }

    public BlackAntBlueprint GetBlackAntToBuild()
    {
        return blackAntToBuild;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectBrick();
        }
    }

}
