using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public DataRes data;
    public UpgradesManager upgradesManager;

    public TMP_Text goldText;
    public TMP_Text foodText;

    public TMP_Text clickPowerGoldText;

    public void Start()
    {
        data = new DataRes();
        upgradesManager.StartUpgradeManager();
        ///wood = new DataRes();

    }

    public  float ClickPower()
    {
        return 1f + data.upgradeLvl;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = data.gold + " Golds";
        foodText.text = data.food + " Foods";
        clickPowerGoldText.text = "+" + ClickPower() + " Golds";
    }

    public void GenerateGold()
    {
        data.gold += ClickPower();
        data.food += 2;
    }
}
