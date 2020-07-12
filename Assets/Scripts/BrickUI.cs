using UnityEngine;

public class BrickUI : MonoBehaviour
{
    public GameObject ui;
    private Brick target;

    public void SetTarget(Brick brick)
    {
        target = brick;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeAnt();
        Building.instance.DeselectBrick();
    }

    public void Sell()
    {
        target.SellTurret();
        Building.instance.DeselectBrick();
    }

}
