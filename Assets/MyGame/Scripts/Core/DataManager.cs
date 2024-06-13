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

    public static float DataMusic
    {
        get => PlayerPrefs.GetFloat(ConstantKey.KeyMusic, 1);
        set => PlayerPrefs.SetFloat(ConstantKey.KeyMusic, value);
    }

    public static float DataSfx
    {
        get => PlayerPrefs.GetFloat(ConstantKey.KeySfx, 1);
        set => PlayerPrefs.SetFloat(ConstantKey.KeySfx, value);
    }

}