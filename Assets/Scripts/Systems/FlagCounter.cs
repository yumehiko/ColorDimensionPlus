using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagCounter : MonoBehaviour
{
    [SerializeField] private StageManager stageManager = default;

    /// <summary>
    /// UIに表示するFlagのPrefab。
    /// </summary>
    [SerializeField] private GameObject flagPrefab = default;
    [SerializeField] private SoundEffect soundEffect = default;

    private List<Animator> flagAnimators = new List<Animator>();
    private readonly string aKeyIsGot = "isGot";

    private bool isWon = false;

    /// <summary>
    /// 今掴んでいるFlagの数。
    /// </summary>
    private int catchedFlags = 0;

    /// <summary>
    /// 勝利に必要なFlagの数を1足す。
    /// </summary>
    public void AddNeedFlag()
    {
        GameObject instance = Instantiate(flagPrefab, transform);
        flagAnimators.Add(instance.GetComponent<Animator>());
    }

    /// <summary>
    /// ゴールできたFlagの数を1足す。
    /// </summary>
    public void AddCatchFlag()
    {
        if (isWon)
        {
            return;
        }

        flagAnimators[catchedFlags].SetBool(aKeyIsGot, true);
        soundEffect.PlaySound(catchedFlags, 1.0f);
        catchedFlags++;
        WinCheck();
    }

    /// <summary>
    /// ゴールできたFlagの数を1引く。
    /// </summary>
    public void SubtractCatchFlag()
    {
        if(isWon)
        {
            return;
        }

        soundEffect.PlaySound(3);
        catchedFlags--;
        flagAnimators[catchedFlags].SetBool(aKeyIsGot, false);
    }

    /// <summary>
    /// ステージを勝利したかチェック。
    /// </summary>
    private void WinCheck()
    {
        if (catchedFlags >= flagAnimators.Count)
        {
            isWon = true;
            stageManager.WinStage();
        }
    }
}
