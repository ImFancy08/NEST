using UnityEngine;

public class Place : MonoBehaviour
{
    public Color placeColor;
    private Color StartColor;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
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
