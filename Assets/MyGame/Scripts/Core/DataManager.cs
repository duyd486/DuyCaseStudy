using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(ConstantKey.KeyCoinId, 0);
        set => PlayerPrefs.SetInt(ConstantKey.KeyCoinId, value);
    }
}