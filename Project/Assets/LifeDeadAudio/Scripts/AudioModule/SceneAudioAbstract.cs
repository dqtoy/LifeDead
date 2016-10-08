//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class SceneAudioAbstract : MonoBehaviour
{

    /// <summary>
    /// 播放游戏主菜单背景音效
    /// </summary>
    public abstract void PlayLoginBGAudio();

    /// <summary>
    /// 播放游戏背景音效
    /// </summary>
    /// <param name="level">关卡序号</param>
    public abstract void PlayBGAudio(int level);

    /// <summary>
    /// 播放死亡场景背景音效
    /// </summary>
    public abstract void PlayDeadBGAudio();
	
}
