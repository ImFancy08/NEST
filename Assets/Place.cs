using UnityEngine;

public class Place : MonoBehaviour
{
    public Color placeColor;

    private GameObject currentTurret;

    private Renderer rend;
    private Color StartColor;
    [SerializeField] private Vector3 posOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(currentTurret!= null)
        {
            Debug.Log("Can't build there! - TODO: Display on Screen");
            return;
        }

        //Build a turret
        GameObject turretToBuild = Building.instance.GetTurret();
        currentTurret = (GameObject) Instantiate(turretToBuild, transform.position + posOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = placeColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

}
