using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SelectCustoms : MonoBehaviour
{
    private Image[] imageArray;

    private Button m_buttonRight;
    private Button m_buttonLeft;

    private  Vector3 LeftPos=new Vector2(-300,300);
    private Vector3 RightPos=new Vector2(1000,300);
    private Vector3 CenterPos=new Vector2(360,300);
   private int index;
   public  int m_levelSum;

    private Button[] m_switchButton;
    void InitImageArray()
    {
        imageArray[0].transform.position = CenterPos;

        for (int i = 1; i < 5; i++)
        {
            imageArray[i].rectTransform.position = RightPos;
        }
    }

    void Awake()
    {

        imageArray = new Image[m_levelSum];
        m_switchButton = new Button[m_levelSum];
        for (int i = 0; i < m_levelSum;i++)
        {
            imageArray[i]= GameObject.Find("customs"+i).GetComponent<Image>();
            m_switchButton[i]=GameObject.Find("customs" + i).GetComponent<Button>();
            m_switchButton[i].onClick.AddListener(SwitchLevel);

        }

        index = 0;
        InitImageArray();
        #region 点击事件注册
        m_buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        m_buttonRight.onClick.AddListener(RightButtonAction);
        m_buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        m_buttonLeft.onClick.AddListener(LeftButtonAction);
        #endregion

    }
    #region 向右点击事件
    public void RightButtonAction()
    {
        if (index < 1)
        {
            return;
        }

        index--;

        Tweener CenterMoveRight = imageArray[index + 1].transform.DOMove(RightPos, 0.5f);
        Tweener LeftMoveCenter = imageArray[index].transform.DOMove(CenterPos, 0.5f);
    }
    #endregion
    #region 向左点击事件
    public void LeftButtonAction()
    {
        if (index > imageArray.Length - 2)
        {
            return;
        }

        index++;

        Tweener CenterMoveLeft = imageArray[index - 1].transform.DOMove(LeftPos, 0.5f);

        Tweener RightMoveCenter = imageArray[index].transform.DOMove(CenterPos, 0.5f);
    }
    #endregion
    public void SwitchLevel()
    {
        SceneManager.LoadScene(2);
    }

}
