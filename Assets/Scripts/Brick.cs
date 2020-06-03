using UnityEngine;
using UnityEngine.EventSystems;
public class Brick : MonoBehaviour
{
    public Color placeColor;

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

    private void OnMouseDown()
    {
        if(!building.CanBuild)
        {
            return;
        }

        if(currentBlackAnt!= null)
        {
            Debug.Log("Can't build there! - Add a UI to display later");
            return;
        }

        //Build a turret
        building.BuildBlackAntOn(this);
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
        rend.material.color = placeColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }


}
