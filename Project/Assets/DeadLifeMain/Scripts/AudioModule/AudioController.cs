//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    private PlayerAudioAbstract m_playerAudioScript;

    private SceneAudioAbstract m_sceneAudioScript;

    void Start()
    {
        m_playerAudioScript = GameObject.FindWithTag(Tags.m_playerAudio).GetComponent<PlayerAudioAbstract>(); ;
        m_sceneAudioScript = GameObject.FindWithTag(Tags.m_sceneAudio).GetComponent<SceneAudioAbstract>();
    }	

    /// <summary>
    /// 返回角色音效播放器
    /// </summary>
    /// <returns></returns>
    public PlayerAudioAbstract GetPlayerAudioScript()
    {
        if(m_playerAudioScript!=null)
        {
            return m_playerAudioScript;
        }
        else
        {
            print("PlayerAudioAbstract方法中返回空的m_playerAudioScript");
            return null;
        }
    }

    /// <summary>
    /// 返回场景音效播放器
    /// </summary>
    /// <returns></returns>
    public SceneAudioAbstract GetSceneAudioAbstract()
    {
        if (m_sceneAudioScript != null)
        {
            return m_sceneAudioScript;
        }
        else
        {
            print("SceneAudioAbstract方法中返回空的m_sceneAudioScript");
            return null;
        }
    }
}
