using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;

    public Upgrades upgrades;

    public float baseCost;
    public float multCost;
    public string upgradeName;


    public void StartUpgradeManager()
    {
        upgradeName = "Golds/click";
        baseCost = 10f;
        multCost = 1.5f;
        UpdateUpgradeUI();
    }


    public float Cost()
    {
        return baseCost * Mathf.Pow(multCost, controller.data.upgradeLvl);
    }


    public void UpdateUpgradeUI()
    {
        upgrades.lvlText.text = controller.data.upgradeLvl.ToString();
        upgrades.costText.text = "Cost : " + Cost() + " Golds";
        upgrades.nameText.text = "+1 " + upgradeName;
    }

    public void BuyUpgrade()
    {
        if (controller.data.gold >= Cost())
        {
            controller.data.gold -= Cost();
            controller.data.upgradeLvl += 1;
        }
        UpdateUpgradeUI();
    }
}
