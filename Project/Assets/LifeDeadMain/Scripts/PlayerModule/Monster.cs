using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	protected GameObject m_player;
	protected PlayerBase m_playerScript;

	// Use this for initialization
	void Start ()
	{	
		Init ();
	}

	protected void Init()
	{
		m_player = GameObject.FindWithTag ("Player");
		m_playerScript = m_player.GetComponent<PlayerBase> ();
	}

	void OnTriggerEnter(Collider other)
	{		
		if (other.gameObject.tag.Equals ("Player")) {
			m_playerScript.PlayerDead ();
		}
	}
}
