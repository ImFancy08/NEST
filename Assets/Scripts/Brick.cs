using UnityEngine;
using UnityEngine.EventSystems;
public class Brick : MonoBehaviour
{
    public Color placeColor;
    public Color notEnoughMoneyColor;

    public GameObject currentBlackAnt;

    private Renderer rend;
    private Color StartColor;
    [SerializeField] private Vector3 posOffset;

    Building building;
    void Start()
    {
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
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject blackAnt = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currentBlackAnt = blackAnt;

        GameObject effect = (GameObject)Instantiate(building.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret Built!");
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(currentBlackAnt!= null)
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
