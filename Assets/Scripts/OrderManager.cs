using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private float orderRate = 2;

    private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    private float orderTimer = 0;
    private bool isStartOrder = false;

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
        }
    }

    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer > orderRate)
        {
            orderTimer = 0;
            OrderANewRecipe();
        }

    }

    private void OrderANewRecipe()
    {
        int index = Random.Range(0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);
    }
}
