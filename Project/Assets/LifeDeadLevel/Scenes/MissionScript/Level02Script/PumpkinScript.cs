//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class PumpkinScript : MonoBehaviour
{
    public GameObject m_moveRockLeft;
    public GameObject m_moveRockRight;
		
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ShowMoveRock();
            Destroy(this.gameObject, 0.2f);
        }
    }

    void ShowMoveRock()
    {
        m_moveRockLeft.SetActive(true);       
    }
}
