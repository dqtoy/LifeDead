//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorWayScript : MonoBehaviour
{

	
	void Start ()
    {
	
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            StartCoroutine("GoToSecletScene");
            
        }
    }

    IEnumerator GoToSecletScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("SelectCustoms");
    }
}
