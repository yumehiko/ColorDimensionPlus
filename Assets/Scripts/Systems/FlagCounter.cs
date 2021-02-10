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

    [SerializeField] private Sprite fillImage = default;
    [SerializeField] private Sprite deFillImage = default;

    [SerializeField] private SoundEffect soundEffect = default;

    /// <summary>
    /// UI上のフラグリスト。
    /// </summary>
    private List<Image> flagImages = new List<Image>();


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
        flagImages.Add(instance.GetComponent<Image>());
    }

    /// <summary>
    /// ゴールできたFlagの数を1足す。
    /// </summary>
    public void AddCatchFlag()
    {
        FillFlagImage(flagImages[catchedFlags]);
        soundEffect.PlaySound(catchedFlags, 1.0f);
        catchedFlags++;
        WinCheck();
    }

    /// <summary>
    /// ゴールできたFlagの数を1引く。
    /// </summary>
    public void SubtractCatchFlag()
    {
        catchedFlags--;
        DeFillFlagImage(flagImages[catchedFlags]);
    }

    /// <summary>
    /// UIのFlagイメージを塗る。
    /// </summary>
    private void FillFlagImage(Image flagImage)
    {
        flagImage.sprite = fillImage;
    }

    /// <summary>
    /// UIのFlagイメージの塗りを戻す。
    /// </summary>
    private void DeFillFlagImage(Image flagImage)
    {
        flagImage.sprite = deFillImage;
    }

    /// <summary>
    /// ステージを勝利したかチェック。
    /// </summary>
    private void WinCheck()
    {
        if (catchedFlags >= flagImages.Count)
        {
            stageManager.WinStage();
        }
    }
}
