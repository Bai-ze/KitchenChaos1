using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //单例模式
    public static OrderManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private int orderMaxCount = 5;
    [SerializeField] private float orderRate = 2;

    private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    private float orderTimer = 0;
    private bool isStartOrder = false;
    private int orderCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isStartOrder = true;
    }

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

    /// <summary>
    /// 生成一个新单子
    /// </summary>
    private void OrderANewRecipe()
    {
        if (orderCount >= orderMaxCount) return;

        orderCount++;
        int index = Random.Range(0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        RecipeSO correctRecipe = null;
        foreach(RecipeSO recipe in orderRecipeSOList)
        {
            if(IsCorrect(recipe, plateKitchenObject))
            {
                correctRecipe = recipe; break;
            }
        }

        if (correctRecipe == null)
        {
            print("上菜失败");
        }
        else
        {
            orderRecipeSOList.Remove(correctRecipe);
            print("上菜成功");
        }
    }

    /// <summary>
    /// 判断上的菜和下单的菜是否一致
    /// </summary>
    /// <param name="recipe">下单的菜</param>
    /// <param name="plateKitchenObject">上的菜</param>
    /// <returns></returns>
    public bool IsCorrect(RecipeSO recipe, PlateKitchenObject plateKitchenObject)
    {
        List<KitchenObjectSO> list1 = recipe.kitchenObjectSOList;
        List<KitchenObjectSO> list2 = plateKitchenObject.GetKitchenObjectSOList();

        if(list1.Count != list2.Count) return false;

        foreach(KitchenObjectSO kitchenObjectSO in list1)
        {
            if(list2.Contains(kitchenObjectSO)==false) return false;
        }

        return true;
    }
}
