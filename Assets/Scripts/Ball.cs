using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ボールの速度
    public float speed = 5.0f;
    // ボールの加速度
    public float acceleration = 0.2f;
    private Rigidbody2D rb2d; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // ボールの位置をリセット
        transform.position = Vector2.zero;

        // ボールの速度のリセット
        rb2d.velocity = Vector2.zero;

        // ボールの初期の速さをリセット
        speed = 5.0f;

        // ランダムな方向に力を加える
        float direction = Random.Range(0, 2) < 1 ? -1 : 1;
        rb2d.velocity = new Vector2(speed * direction, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // パドルとの衝突時
        if (collision.gameObject.name == "PlayerPaddle" || collision.gameObject.name == "ComputerPaddle")
        {
            Vector2 direction = transform.position - collision.transform.position;
            rb2d.velocity = direction.normalized * speed;
            rb2d.velocity = rb2d.velocity.normalized * speed;
        }
         speed += acceleration;
    }
       
    // Add this method
    void ResetBall()
    {
        LaunchBall();
    }
}
