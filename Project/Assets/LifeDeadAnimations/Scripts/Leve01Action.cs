//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leve01Action : MonoBehaviour {

    private Text m_maskText;
    private GameObject m_maskBg;
    private GameObject m_girl;
    private GameObject m_letterPaper;
    private GameObject m_letterPaperEndPos;
    private float m_speed;
    private float m_letterX;
    private bool m_isMove;

    void Awake()
    {
        m_speed = 0.8f;
        m_isMove = false;
        m_maskText = GameObject.FindWithTag("MaskText").GetComponent<Text>();
        m_maskBg = GameObject.FindWithTag("MaskBg");
        m_girl = GameObject.FindWithTag("Player");
        m_letterX = GameObject.FindWithTag("Letter").transform.position.x;
        m_letterPaper = GameObject.FindWithTag("LetterPaper");
        m_letterPaperEndPos = GameObject.FindWithTag("LetterPaperEndPos");
    }

	void Start ()
    {       
        string content = "小 女 孩 Lisa 在 一 天 晚 上 醒 来 发 现 周 围 的 一 切 都 变 了, 这 并 不 是 她 原 来 所 认 识 的 世 界， 亲 人？ 朋 友？ 他 们 都 在 哪 里？ 为 什 么 只 留 下 她 一 个 人 在 这 里 。。。";
        Tweener tweener = m_maskText.DOText(content, 15);
        tweener.OnComplete(OnTweenComplete);      
    }

    void OnTweenComplete()
    {
        m_maskText.gameObject.SetActive(false);
        Tweener tweener =  m_maskBg.transform.DOMove((m_maskBg.transform.position + Vector3.up * -20), 2f);
        tweener.OnComplete(OnTweenCompleteTwo);              
    }

    void OnTweenCompleteTwo()
    {
        StartCoroutine("MyIEnumerator");
    }

    
    IEnumerator MyIEnumerator()
    {
        yield return new WaitForSeconds(1);
        m_isMove = true;
    }


    void Update()
    {
        
        if(m_isMove)
        {
            m_girl.GetComponent<GirlScript>().PlayerMove(m_speed);
        }

        if (Mathf.Abs(m_letterX-m_girl.transform.position.x)<1)
        {
            m_girl.GetComponent<GirlScript>().PlayerMove(0);
            m_isMove = false;
            StartCoroutine("MyIEnumeratorTwo");
        }
    }


    IEnumerator MyIEnumeratorTwo()
    {
        yield return new WaitForSeconds(1);
        Tweener tweener = m_letterPaper.transform.DOMove(m_letterPaperEndPos.transform.position, 2f);
        tweener.OnComplete(RebackSelectScene);
    }

    void RebackSelectScene()
    {
        StartCoroutine("MyIEnumeratorThree");
    }


    IEnumerator MyIEnumeratorThree()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SelectCustoms");
    }

   
}
