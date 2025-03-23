using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    private BaseCounter selectedCounter;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnOperaterAction += GameInput_OnOperaterAction;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }

    /// <summary>
    /// 和柜台交互
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        //HandleInteraction();
        selectedCounter?.Interact(this);
    }

    private void GameInput_OnOperaterAction(object sender, System.EventArgs e)
    {
        selectedCounter?.InteractOperate(this);
    }

    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;

        transform.position += direction * Time.deltaTime * moveSpeed;

        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
            //transform.forward = direction;
        }
    }

    /// <summary>
    /// 监测哪一个柜台处于可交互状态
    /// </summary>
    private void HandleInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))
        {
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                SetSelectedCounter(counter);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    /// <summary>
    /// 把旧的柜台取消选择，选择新的柜台，并更新字段
    /// </summary>
    /// <param name="counter"></param>
    public void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectedCouter();
        }
        this.selectedCounter = counter;
    }
}
