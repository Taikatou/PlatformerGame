using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text coinText;

    private int _coinCount;

    private List<IResetAble> _resetList;

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

    public void AddResetAble(IResetAble resetAble)
    {
        _resetList.Add(resetAble);
    }

    public void Reset()
    {
        foreach (IResetAble toReset in _resetList)
        {
            toReset.Reset(this);
        }
        _resetList.Clear();
    }

    public void CheckPoint()
    {
        foreach (IResetAble toReset in _resetList)
        {
            toReset.Destroy();
        }
        _resetList.Clear();
    }

    private void Start()
    {
        CoinCount = 0;
        _resetList = new List<IResetAble>();
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
