using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadHead : MonoBehaviour
{
    #region 字段
    private Image m_headImage;
    private string m_playerName;
    private Sprite m_playerHeadSprite;
    #endregion
    #region 初始化
    void Awake()
    {
        // 获取名字
        m_playerName = PlayerPrefs.GetString("PlayerName");
        // 拼接字符串
        m_playerName = m_playerName + "ImageHead";
        // 从Resources文件夹获取头像
        m_playerHeadSprite = Resources.Load<Sprite>(m_playerName);
    }

    void Start()
    {
        m_headImage = this.GetComponent<Image>();
        m_headImage.sprite = m_playerHeadSprite;
    }
    #endregion


}
