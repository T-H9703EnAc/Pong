using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    // パドルの速度
    public float speed = 10.0f;
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
        // 上下のキー入力を取得
        float verticalInput = Input.GetAxis("Vertical");
        // 新しい位置を計算
        Vector2 newPosition = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);

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
