using UnityEngine;

public class Shop : MonoBehaviour
{
    Building building;

    private void Start()
    {
        building = Building.instance;
    }

    public void BuyNormalBAnt()
    {
        Debug.Log("Buy Normal Black Ant");
        building.SetBAntToBuild(building.normalBAnt);
    }
    public void BuyAOEAnt()
    {
        Debug.Log("Buy AOE Black Ant");
        building.SetBAntToBuild(building.slowBAnt);

    }
    public void BuySlowAnt()
    {
        Debug.Log("Buy Slow Black Ant");
        building.SetBAntToBuild(building.laserBAnt);

    }
}
