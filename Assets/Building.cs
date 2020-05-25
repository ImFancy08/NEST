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

    private GameObject bAntToBuild;

    public GameObject GetBAntToBuild()
    {
        return bAntToBuild;
    }

    public void SetBAntToBuild(GameObject BAnt)
    {
        bAntToBuild = BAnt;
    }
}
