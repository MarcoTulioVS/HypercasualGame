using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
public class ItemManager : Singleton<ItemManager>
{
  
    public SOInt coins;
    public SOInt planets;
    private void Start()
    {
        Reset();
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        //UpdateUI();
    }

    public void AddPlanet(int amount = 1)
    {
        planets.value += amount;
        //UpdateUIPlanet();
    }

    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;
    }

    private void UpdateUI()
    {
        UIInGameManager.instance.uiTextCoins.text = coins.value.ToString();
        
        
    }
    private void UpdateUIPlanet()
    {

        UIInGameManager.instance.uiTextPlanets.text = planets.value.ToString();
    }
}
