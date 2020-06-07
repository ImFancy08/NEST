 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    [SerializeField]public static int WavesCount = 0;
    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        WavesCount = 0;  
    }

}
