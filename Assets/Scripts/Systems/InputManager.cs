using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

/// <summary>
/// 入力を受け付ける。
/// </summary>
public class InputManager : MonoBehaviour
{

    private CharaControl currentPlayerControl = default;

    private List<Player> players = new List<Player>();

    private int currentPlayerID = 0;

    private void Start()
    {
        players = GetPlayers();
        currentPlayerControl = players[0].GetControl(false);
    }

    /// <summary>
    /// 子オブジェクトのプレイヤーをすべて取得。
    /// </summary>
    private List<Player> GetPlayers()
    {
        List<Player> newPlayerList = new List<Player>();

        for (int i = 0; i < transform.childCount; i++)
        {
            newPlayerList.Add(transform.GetChild(i).GetComponent<Player>());
        }

        return newPlayerList;
    }

    private void Update()
    {
        InGameKeyInput();
    }

    /// <summary>
    /// ゲーム中のプレイヤー操作。
    /// </summary>
    private void InGameKeyInput()
    {
        if(currentPlayerControl == null)
        {
            return;
        }

        currentPlayerControl.InputHorizontal = Input.GetAxis("Horizontal");
        currentPlayerControl.InputVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPlayerControl.Jump();
        }

        InputSwapKey();
        
    }

    /// <summary>
    /// スワップ（プレイヤーの操作対象を変更すること）の入力。
    /// </summary>
    private void InputSwapKey()
    {
        if(players.Count == 1)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LosePlayerControl();
            currentPlayerControl = SwapControlPlayer(-1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            LosePlayerControl();
            currentPlayerControl = SwapControlPlayer(1);
        }
    }

    /// <summary>
    /// コントロールする対象を切り替える。
    /// </summary>
    private CharaControl SwapControlPlayer(int next)
    {
        Player currentPlayer = players[currentPlayerID];
        SortPlayersByX();
        currentPlayerID = players.IndexOf(currentPlayer);

        currentPlayerID += next;
        if(currentPlayerID >= players.Count)
        {
            currentPlayerID = 0;
        }
        else if(currentPlayerID < 0)
        {
            currentPlayerID = players.Count - 1;
        }

        return players[currentPlayerID].GetControl(true);
    }

    /// <summary>
    /// playerPositionXをx座標順にソート。
    /// </summary>
    private void SortPlayersByX()
    {
        players.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
    }

    /// <summary>
    /// プレイヤーコントロールを放棄
    /// </summary>
    public void LosePlayerControl()
    {
        currentPlayerControl.LoseInitiative();
        currentPlayerControl = null;
    }
}
