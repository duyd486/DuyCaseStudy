using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.coinEventUpdate.AddListener(AddUiCoin);
        textCoin.text = DataManager.DataCoin.ToString();
    }

    private void AddUiCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
}