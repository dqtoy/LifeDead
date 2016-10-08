using UnityEngine;
using System.Collections;

public class PlayerAudio : PlayerAudioAbstract 
{

	private AudioClip Girl_Death;
	private AudioClip Man_Death;
	private AudioClip Walk;
	private AudioClip Knife;
	private AudioClip Jump;
	private AudioClip Laser;
	private AudioSource PlayerAudios;
	public void Start(){
		PlayerAudios =GameObject.Find("PlayerAudio").GetComponent<AudioSource> ();
	}

	public override void PlayJumpAudio(){
		PlayerAudios.clip = Resources.Load ("jump")as AudioClip;
		PlayerAudios.Play ();
	}
	public override void PlayGirlDeadAudio(){
		PlayerAudios.clip = Resources.Load ("Girl_Death")as AudioClip;
		PlayerAudios.Play ();
	}
	public override void PlayManDeadAudio (){
		PlayerAudios.clip =Resources.Load ("Man_Death")as AudioClip;
		PlayerAudios.Play ();
	}
	public override void PlayWalkAudio(){
		PlayerAudios.clip = Resources.Load ("walk")as AudioClip;
		PlayerAudios.Play ();
	}
	public override void PlayLaserAudio(){
		PlayerAudios.clip = Resources.Load ("laser")as AudioClip;
		PlayerAudios.Play ();
	}
	public override void PlayKnifeAudio(){
		PlayerAudios.clip = Resources.Load ("knife")as AudioClip;
		PlayerAudios.Play ();
	}
}
