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

    private void Start()
    {
        turretToBuild = normalBAnt;
    }

    private GameObject turretToBuild;

    public GameObject GetTurret()
    {
        return turretToBuild;
    }
}
