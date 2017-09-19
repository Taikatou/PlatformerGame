using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text coinText;

    private int _coinCount;
    public int CoinCount
    {
        get
        {
            return _coinCount;
        }
        set
        {
            _coinCount = value;
            coinText.text = "Coins: " + CoinCount;
        }
    }

    List<IResetAble> resetList;

    public void AddResetAble(IResetAble resetAble)
    {
        resetList.Add(resetAble);
    }

    public void Reset()
    {
        foreach (IResetAble toReset in resetList)
        {
            toReset.Reset(this);
        }
        resetList.Clear();
    }

    public void CheckPoint()
    {
        foreach (IResetAble toReset in resetList)
        {
            toReset.Destroy();
        }
        resetList.Clear();
    }

    private void Start()
    {
        CoinCount = 0;
        resetList = new List<IResetAble>();
    }

    public void AddCoin(int coinNum = 1)
    {
        CoinCount += coinNum;
    }

    public void RemoveCoin(int coinNum=1)
    {
        CoinCount -= coinNum;
    }
}
