using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SelectPlayer : MonoBehaviour
{

    private Button m_leftButton;
    private Button m_rightButton;
    private Button m_startButton;

    private Text m_introText;

    private Vector3 m_startPos;
    private Vector3 m_endPos;
    private float m_offestPos;
    private bool m_isDrag;

    GameObject Knight;
    public GameObject[] m_Players;
    
    
    void Awake()
    {
        #region Button按钮注册事件
        m_leftButton = GameObject.Find("TurnLeftButton").GetComponent<Button>();
        m_leftButton.onClick.AddListener(LeftButtonAction);

        m_rightButton = GameObject.Find("TurnRightButton").GetComponent<Button>();
        m_rightButton.onClick.AddListener(RightButtonAction);

        m_startButton = GameObject.Find("StartButton").GetComponent<Button>();
        m_startButton.onClick.AddListener(StartButtonAction);
        #endregion

        m_isDrag = false;
        m_introText = GameObject.Find("IntroText").GetComponent<Text>();

        Knight = GameObject.Find("Knight");
    }
    
    
    void Update()
    {

        
        
    }
    #region 左键点击事件
    public void LeftButtonAction()
    {

    }
    #endregion
    #region 右键点击事件
    public void RightButtonAction()
    {

    }
    #endregion
    #region 开始按钮点击事件
    public void StartButtonAction()
    {

    }
    #endregion
    #region 拖动选择人物

    

    #endregion

}
