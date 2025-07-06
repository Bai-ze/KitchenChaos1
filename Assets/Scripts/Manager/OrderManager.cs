using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //单例模式
    public static OrderManager Instance { get; private set; }

    //发布-订阅
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeSuccessed; //上菜成功
    public event EventHandler OnRecipeFailed; //上菜失败

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
        GameManager.Instance.OnStateChanged += GameManage_OnStateChanged;
    }

    private void GameManage_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {
            StartSpawnOrder();
        }
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
        int index = UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);

        OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
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
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            orderRecipeSOList.Remove(correctRecipe);
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
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

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }

    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }
}
