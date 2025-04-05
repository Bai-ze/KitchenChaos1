using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platesCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO plateSO;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private int plateCounterMax = 5;

    private List<KitchenObject> platesList = new List<KitchenObject>();

    private float timer = 0;

    private void Update()
    {
        if(platesList.Count < plateCounterMax)
        {
            timer += Time.deltaTime;
        }
        if (timer > spawnRate)
        {
            timer = 0;
            SpawnPlate();
        }
    }

    public override void Interact(Player player)
    {
        base.Interact(player);
    }

    public void SpawnPlate()
    {
        if (platesList.Count >= plateCounterMax)
        {
            timer = 0;
            return;
        }
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();

        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;

        platesList.Add(kitchenObject);
    }
}
