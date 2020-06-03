using UnityEngine;

public class Shop : MonoBehaviour
{
    public BlackAntBlueprint standardBlackAnt;
    public BlackAntBlueprint aoeBlackAnt;
    public BlackAntBlueprint slowBlackAnt;

    Building building;


    private void Start()
    {
        building = Building.instance;
    }

    public void SelectNormalBAnt()
    {
        Debug.Log("Normal Black Ant");
        building.SelectBlackAntToBuild(standardBlackAnt);
    }
    public void SelectAOEAnt()
    {
        Debug.Log("AOE Black Ant");
        building.SelectBlackAntToBuild(aoeBlackAnt);

    }
    public void SelectSlowAnt()
    {
        Debug.Log("Slow Black Ant");
        building.SelectBlackAntToBuild(slowBlackAnt);

    }
}
