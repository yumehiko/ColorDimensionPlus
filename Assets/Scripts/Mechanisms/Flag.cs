using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 旗。全ての色の旗に触れるとステージ勝利。
/// </summary>
public class Flag : MonoBehaviour
{
    private FlagCounter flagCounter = default;
    private bool isCatched = false;


    void Start()
    {
        flagCounter = GameObject.Find("FlagCounter").GetComponent<FlagCounter>();
        flagCounter.AddNeedFlag();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CatchFlag();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MissFlag();
        }
    }


    /// <summary>
    /// この旗を掴む。
    /// </summary>
    private void CatchFlag()
    {
        if (isCatched)
        {
            return;
        }
        flagCounter.AddCatchFlag();
        isCatched = true;
    }

    /// <summary>
    /// この旗を離す。
    /// </summary>
    private void MissFlag()
    {
        if(!isCatched)
        {
            return;
        }
        flagCounter.SubtractCatchFlag();
        isCatched = false;
    }
}
