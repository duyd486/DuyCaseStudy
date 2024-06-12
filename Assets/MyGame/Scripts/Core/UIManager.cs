using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[AddComponentMenu("DangSon/UIManager")]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.coinEventUpdate.AddListener(AddUiCoin);
    }

    private void AddUiCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
}