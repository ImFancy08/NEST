using UnityEngine;
using UnityEngine.UI;
public class BrickUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject questionManager;
    private Brick target;
    public Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Brick brick)
    {
        target = brick;

        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = target.blackAntBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
        questionManager.SetActive(false);
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

    public void Question()
    {
        Hide();
        questionManager.SetActive(true);
    }

    public void No()
    {
        Hide();
        questionManager.SetActive(false);
    }
}
