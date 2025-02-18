﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 橋板を表示、非表示を繰り返しているだけ

public class LongFallingFloor : MonoBehaviour
{
    public float FallingSpeed = 2.0f;

    public float FallingEndPosition = -2.0f;

    private Vector3[] GetChildPosition = new Vector3[18];

    private Vector3[] GetStartPos = new Vector3[18];

    public static bool LongPassFlag = false; //橋を通ったか

    private int Count = 0; //橋の枚数カウント

    private int i = 0;

    private int Value = 18;
    private int MaxValue = 17;

    public float CountTime = 0.0f;
    private float CountTimeMax = 0.2f;

    void Start()
    {
        for (int j = 0; j < Value; j++)
        {
            GetChildPosition[j] = transform.GetChild(j).gameObject.transform.position;
            GetStartPos[j] = transform.GetChild(j).gameObject.transform.position;

            // 最初に消しとく
            transform.GetChild(j).gameObject.SetActive(false);
        }
    }
    void Update()
    {

        //// 死んだら
        if (PlayerHP.FadeIn == true)
        {
            // 位置更新
            for (i = 0; i < Value; i++)
            {
                GetChildPosition[i] = GetStartPos[i];
                transform.GetChild(i).gameObject.SetActive(false);
            }

            Count = 0;

            if (PlayerState.EventEndFlag[1] == true) //一回イベントを見ていたら橋を表示
            {
                LongPassFlag = true;
            }
        }



        // イベント後
        if (LongPassFlag == true)
        {
            transform.GetChild(Count).gameObject.SetActive(true);
            CountTime -= Time.deltaTime;

            if (CountTime < 0)
            {
                Count++;
                CountTime = CountTimeMax;
            }
        }

        if (Count > MaxValue)
        {
            LongPassFlag = false;
            ReturmGame.RestartFlag[1] = false;
            Count = 0;
        }

    }
}

