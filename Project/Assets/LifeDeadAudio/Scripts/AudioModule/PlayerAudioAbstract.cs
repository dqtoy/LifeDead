//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public abstract class PlayerAudioAbstract : MonoBehaviour
{

    /// <summary>
    /// 播放Player跳跃的音效 Playr通用
    /// </summary>
    public abstract void PlayJumpAudio();

    /// <summary>
    /// 播放Player死亡音效 Playr通用
    /// </summary>
    public abstract void PlayGirlDeadAudio();
	public abstract void PlayManDeadAudio ();

    /// <summary>
    /// 播放Player行走音效 Playr通用
    /// </summary>
    public abstract void PlayWalkAudio();
    /// <summary>
    /// 播放独眼怪发射激光音效 
    /// </summary>
    public abstract void PlayLaserAudio();

    /// <summary>
    /// 播放武士扔飞刀音效
    /// </summary>
    public abstract void PlayKnifeAudio();
}
