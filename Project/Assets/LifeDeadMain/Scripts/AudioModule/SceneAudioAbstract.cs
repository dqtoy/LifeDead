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
    ///  从Resources文件夹加载所有背景的音效资源
    /// </summary>
    public abstract void LoadSceneAudioClips();

    /// <summary>
    /// 获取刚体组件
    /// </summary>
    public abstract void AddRigidbodyCom();

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
	public abstract void PlayButtonAudioA ();
	public abstract void PlayButtonAudioB ();
	public abstract void PlayEatAudio ();
	public abstract void PlayPauseAudio();
	public abstract void PlayWriteBGMAudio ();
	public abstract void PlayDrinkAudio();
	public abstract void PlayFinishAudio();
	public abstract void PlaySelectAudio ();

	
}
