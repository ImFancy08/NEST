using System;
using System.Data.SqlTypes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class Building : MonoBehaviour
{
    public static Building instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one Building is in the scene");
            return;
        }
        instance = this;
    }

    public GameObject normalBAnt;
    public GameObject aoeBAnt;
    public GameObject slowBAnt;

    public GameObject buildEffect;

    private BlackAntBlueprint blackAntToBuild;

    public bool CanBuild { get { return blackAntToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= blackAntToBuild.cost; } }

    private Brick selectedBrick;

    public void SelectBrick(Brick brick)
    {
        selectedBrick = brick;
        blackAntToBuild = null;
    }

    public void SelectBlackAntToBuild(BlackAntBlueprint blackAnt)
    {
        blackAntToBuild = blackAnt;
        selectedBrick = null;
    }

    public void BuildBlackAntOn(Brick brick)
    {
        if(PlayerStats.Money < blackAntToBuild.cost)
        {
            Debug.Log("Not Enough Money to Build That!!!");
            return;
        }

        PlayerStats.Money -= blackAntToBuild.cost;
        GameObject blackAnt = (GameObject)Instantiate(blackAntToBuild.prefab, brick.GetBuildPosition(), Quaternion.identity);
        brick.currentBlackAnt = blackAnt;

        GameObject effect = (GameObject) Instantiate(buildEffect, brick.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret Built! Money Left: " + PlayerStats.Money); 
    }
}
