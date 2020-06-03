using System;
using System.Data.SqlTypes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
    public GameObject slowBAnt;
    public GameObject laserBAnt;

    private BlackAntBlueprint bAntToBuild;

    public bool CanBuild { get { return bAntToBuild != null; } }

    public void SelectBlackAntToBuild(BlackAntBlueprint blackAnt)
    {
        bAntToBuild = blackAnt;
    }

    public  void BuildBlackAntOn(Brick brick)
    {
        if(PlayerStats.Money < bAntToBuild.cost)
        {
            Debug.Log("Not Enough Money to Build That!!!");
            return;
        }

        PlayerStats.Money -= bAntToBuild.cost;
        GameObject blackAnt = (GameObject)Instantiate(bAntToBuild.prefab, brick.GetBuildPosition(), Quaternion.identity);
        brick.currentBlackAnt = blackAnt;

        Debug.Log("Turret Built! Money Left: " + PlayerStats.Money); 
    }
}
