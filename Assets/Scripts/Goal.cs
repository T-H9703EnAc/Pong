using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // プレイヤーのゴールかどうか
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

            if (isPlayerGoal)
            {
                scoreManager.AddScoreToPlayer();
            }
            else
            {
                scoreManager.AddScoreToComputer();
            }

            // 位置をリセット
            collision.gameObject.SendMessage("ResetBall");
            GameObject.Find("PlayerPaddle").SendMessage("ResetPaddle");
            GameObject.Find("ComputerPaddle").SendMessage("ResetPaddle");
            
        }
    }
}
