using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManeger_OnStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.IsCountDownState())
        {
            numberText.text = Mathf.CeilToInt(GameManager.Instance.GetCountDownTimer()).ToString();
        }
    }

    private void GameManeger_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountDownState())
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
            numberText.gameObject.SetActive(false);
        }
    }
}
