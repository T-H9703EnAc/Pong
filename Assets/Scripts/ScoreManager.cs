using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // プレイヤーのスコア
    public static int playerScore = 0;
    // コンピュータのスコア
    public static int computerScore = 0;
    // プレイヤーのスコアを表示するテキスト
    public Text playerScoreText;
    // コンピュータのスコアを表示するテキスト
    public Text computerScoreText;
    // 勝利に必要なスコア
    public int winningScore = 10;
    // ゲームクリアテキストへの参照
    public Text gameClearText;
    // ゲームオーバーテキストへの参照
    public Text gameOverText;
    // 再プレイボタンへの参照
    public Button replayButton;
    // メニューボタンへの参照
    public Button menuButton;

    private void Start()
    {
        // 初期状態ではゲームオーバーテキストとボタンは非表示
        gameClearText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        // ボタンのクリックイベントに対応する関数を設定
        replayButton.onClick.AddListener(ReplayGame);
        menuButton.onClick.AddListener(GoToMenu);
    }

    // プレイヤーのスコアを加算し、テキストを更新
    public void AddScoreToPlayer()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();

        // 勝利の確認
        if (playerScore >= winningScore)
        {
            // ゲームクリアテキストとボタンを表示
            gameClearText.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);

            // ゲームの時間を停止
            Time.timeScale = 0;
        }
    }

    // コンピュータのスコアを加算し、テキストを更新
    public void AddScoreToComputer()
    {
        computerScore++;
        computerScoreText.text = computerScore.ToString();

        // 勝利の確認
        if (computerScore >= winningScore)
        {
            // ゲームオーバーテキストとボタンを表示
            gameOverText.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);

            // ゲームの時間を停止
            Time.timeScale = 0;
        }
    }

    // ゲームをリプレイ
    public void ReplayGame()
    {
        // ゲームの時間の流れを再開
        Time.timeScale = 1;

        // 現在のシーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // プレイヤーのスコアを初期化
        playerScore = 0;
        // コンピュータのスコアを初期化
        computerScore = 0;
    }

    // メインメニューへ戻る
    public void GoToMenu()
    {
        // ゲームの時間の流れを再開
        Time.timeScale = 1;

        // メインメニューシーンへ切り替え（シーン名はプロジェクトによる）
        SceneManager.LoadScene("Main");
    }

}
