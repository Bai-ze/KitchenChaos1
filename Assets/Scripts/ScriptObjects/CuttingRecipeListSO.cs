using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CuttingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
}

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;

    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        foreach(CuttingRecipe recipe in list)
        {
            if (recipe.input == input)
            {
                return recipe.output;
            }
        }
        return null;
    }
}
