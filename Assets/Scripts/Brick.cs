using UnityEngine;
using UnityEngine.EventSystems;
public class Brick : MonoBehaviour
{
    public Color placeColor;

    private GameObject currentTurret;

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

    private void OnMouseDown()
    {
        if(building.GetBAntToBuild() == null)
        {
            return;
        }

        if(currentTurret!= null)
        {
            Debug.Log("Can't build there! - Add a UI to display later");
            return;
        }

        //Build a turret
        GameObject turretToBuild = building.GetBAntToBuild();
        currentTurret = (GameObject) Instantiate(turretToBuild, transform.position + posOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }    

        if (building.GetBAntToBuild() == null)
        {
            return;
        }
        rend.material.color = placeColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

}
