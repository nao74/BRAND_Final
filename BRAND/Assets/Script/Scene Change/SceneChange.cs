﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "playerMove")
        {
            if (other.tag == "Player")
            {
                Reset(); //イベントとかリセット
                CloseSystem.SecondGame();
            }
        }
        if (SceneManager.GetActiveScene().name == "stage2")
        {
            if (other.tag == "Player")
            {
                Reset(); //イベントとかリセット

                CloseSystem.CloseGame();
            }
        }
    }

    private void Reset()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerState.EventEndFlag[i] = false; //イベントリセット
        }

        PlayerState.MidPointFlag = false; //中間ポイントに来てないことにする

        MidPointDisplay.PointDisplay = false; //中間ポイントを非表示

    }
}
