using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{  
    // パドルの速度
    public float speed = 10.0f;
    // ボールオブジェクトへの参照
    public GameObject ball; 
    // パドルの移動範囲
    public float boundaryY = 4.5f;
    // パドルの初期位置
    private Vector2 initialPosition;

    private void Start()
    {
        // パドルの初期位置を保存
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (ball.transform.position.y > transform.position.y) 
        {
            // ボールがパドルより上にある場合
            MoveUp();
        }
        else if (ball.transform.position.y < transform.position.y) 
        {
            // ボールがパドルより下にある場合
            MoveDown();
        }
    }

    private void MoveUp()
    {
        // パドルを上に移動
        Vector2 newPosition = transform.position + new Vector3(0, speed * Time.deltaTime, 0); 

        // Y座標がboundaryYを超えないようにする
        newPosition.y = Mathf.Clamp(newPosition.y, -boundaryY, boundaryY);

        // パドルの位置を更新
        transform.position = newPosition;
    }

    private void MoveDown()
    {
        // パドルを下に移動
        Vector2 newPosition = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);

        // Y座標がboundaryYを超えないようにする
        newPosition.y = Mathf.Clamp(newPosition.y, -boundaryY, boundaryY);

        // パドルの位置を更新
        transform.position = newPosition;
    }

    // パドルの位置をリセットする関数
    public void ResetPaddle()
    {
        transform.position = initialPosition;
    }

}
