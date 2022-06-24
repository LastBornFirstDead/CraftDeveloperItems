using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

public class CraftDevItems : Mod
{
    public void Start()
    {
        Item_Base[] metalItem = new Item_Base[] { ItemManager.GetItemByName("MetalIngot") };
        Item_Base[] copperItem = new Item_Base[] { ItemManager.GetItemByName("CopperIngot") };
        Item_Base[] titaniumItem = new Item_Base[] { ItemManager.GetItemByName("TitaniumIngot") };
        Item_Base[] glassItem = new Item_Base[] { ItemManager.GetItemByName("Glass") };
        Item_Base[] redFlowerItem = new Item_Base[] { ItemManager.GetItemByName("Flower_Red") };
        Item_Base[] blueFlowerItem = new Item_Base[] { ItemManager.GetItemByName("Flower_Blue") };
        Item_Base[] nailItem = new Item_Base[] { ItemManager.GetItemByName("Nail") };
        Item_Base[] scrapItem = new Item_Base[] { ItemManager.GetItemByName("Scrap") };
        Item_Base[] plasticItem = new Item_Base[] { ItemManager.GetItemByName("Plastic") };
        CreateRecipe(ItemManager.GetItemByName("DevSpear"), 1, new CostMultiple(metalItem, 60), new CostMultiple(copperItem, 40), new CostMultiple(titaniumItem, 20));
        CreateRecipe(ItemManager.GetItemByName("Hat_Dev"), 1, new CostMultiple(glassItem, 2), new CostMultiple(redFlowerItem, 6), new CostMultiple(blueFlowerItem, 6), new CostMultiple(nailItem, 1), new CostMultiple(scrapItem, 2), new CostMultiple(plasticItem, 10));


        Debug.Log("Mod Craft Dev Items has been loaded!");
    }

    /// <summary>
    /// Function creating a new recipe setting with new recipe.
    /// </summary>
    /// <param name="pResultItem">Item resulting from the crafting.</param>
    /// <param name="pAmount">Crafting-Output Amount.</param>
    /// <param name="pCosts">Crafting costs.</param>
    public static void CreateRecipe(Item_Base pResultItem, int pAmount, params CostMultiple[] pCosts)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("newCostToCraft").SetValue(pCosts);
        Traverse.Create(pResultItem.settings_recipe).Field("learned").SetValue(false);
        Traverse.Create(pResultItem.settings_recipe).Field("learnedFromBeginning").SetValue(false);
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Other);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public void OnModUnload()
    {
        Debug.Log("Mod Craft Dev Items has been unloaded!");
    }
}