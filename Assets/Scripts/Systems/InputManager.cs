using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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
        for(int i=0; i< transform.childCount; i++)
        {
            players.Add(transform.GetChild(i).GetComponent<Player>());
        }

        currentPlayerControl = players[0].GetControl(false);
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

        if(Input.GetKeyDown(KeyCode.X))
        {
            LosePlayerControl();
            currentPlayerControl = SwapControlPlayer(-1);
        }
        else if(Input.GetKeyDown(KeyCode.Z))
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
    /// プレイヤーコントロールを放棄
    /// </summary>
    public void LosePlayerControl()
    {
        currentPlayerControl.LoseInitiative();
        currentPlayerControl = null;
    }
}
