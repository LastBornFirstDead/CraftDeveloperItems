using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

public class CraftDevItems : Mod
{
    public void Start()
    {
        CreateRecipe(ItemManager.GetItemByName("DevSpear"), 1);
        CreateRecipe1(ItemManager.GetItemByName("BeachBall"), 1);
        CreateRecipe2(ItemManager.GetItemByName("DevHat"), 1);
        Debug.Log("Mod Craft Dev Items has been loaded!");
        allowItems("");
        allowItems2("");
        allowItems3("");
    }
    private void allowItems(params string[] validItemNames)
    {
        var metalItem = ItemManager.GetItemByName("MetalIngot");
        var metalIngredient = new CostMultiple(new Item_Base[] { metalItem }, 60);

        var copperItem = ItemManager.GetItemByName("CopperIngot");
        var copperIngredient = new CostMultiple(new Item_Base[] { copperItem }, 40);

        var titaniumItem = ItemManager.GetItemByName("TitaniumIngot");
        var titaniumIngredient = new CostMultiple(new Item_Base[] { titaniumItem }, 20);

        var dev = ItemManager.GetItemByName("DevSpear");
        dev.settings_recipe.NewCost = new CostMultiple[] { metalIngredient, copperIngredient, titaniumIngredient };
    }

    private void allowItems2(params string[] validItemNames)
    {
        var plasticItem = ItemManager.GetItemByName("Plastic");
        var plasticIngredient = new CostMultiple(new Item_Base[] { plasticItem }, 10);

        var plastic = ItemManager.GetItemByName("BeachBall");
        plastic.settings_recipe.NewCost = new CostMultiple[] { plasticIngredient };
    }

    private void allowItems3(params string[] validItemNames)
    {
        var glassItem = ItemManager.GetItemByName("Glass");
        var glassIngredient = new CostMultiple(new Item_Base[] { glassItem }, 2);

        var redItem = ItemManager.GetItemByName("Flower_Red");
        var redIngredient = new CostMultiple(new Item_Base[] { redItem }, 6);

        var blueItem = ItemManager.GetItemByName("Flower_Blue");
        var blueIngredient = new CostMultiple(new Item_Base[] { blueItem }, 6);

        var nailItem = ItemManager.GetItemByName("Nail");
        var nailIngredient = new CostMultiple(new Item_Base[] { nailItem }, 1);

        var scrapItem = ItemManager.GetItemByName("Scrap");
        var scrapIngredient = new CostMultiple(new Item_Base[] { scrapItem }, 2);

        var plasticItem = ItemManager.GetItemByName("Plastic");
        var plasticIngredient = new CostMultiple(new Item_Base[] { plasticItem }, 10);

        var hat = ItemManager.GetItemByName("DevHat");
        hat.settings_recipe.NewCost = new CostMultiple[] { glassIngredient, redIngredient, blueIngredient, nailIngredient, scrapIngredient, plasticIngredient };
    }

    /// <param name="pResultItem">Item resulting from the crafting.</param>
    public static void CreateRecipe(Item_Base pResultItem, int pAmount)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Weapons);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public static void CreateRecipe1(Item_Base pResultItem, int pAmount)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Other);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public static void CreateRecipe2(Item_Base pResultItem, int pAmount)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Equipment);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public void OnModUnload()
    {
        Debug.Log("Mod Craft Dev Items has been unloaded!");
    }
}