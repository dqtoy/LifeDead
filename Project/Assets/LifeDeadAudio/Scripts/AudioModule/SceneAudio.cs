using UnityEngine;
using System.Collections;

public class SceneAudio : SceneAudioAbstract {
	private AudioClip ForestBGM;
	private AudioClip DBGM;
	private AudioClip Login;
	private AudioClip SummerBGM;
	private AudioClip SwampBGM;
	private AudioClip Button_01;
	private AudioClip Button_02;
	private AudioClip Eat;
	private AudioClip Pause;
	private AudioClip Select;
	private AudioClip Drink;
	private AudioClip WriteBGM;
	private AudioClip Finish;
	private AudioSource SceneAudios;
	public override void LoadSceneAudioClips(){
	}
	public override void AddRigidbodyCom(){
	}
	void Start(){
		SceneAudios = GameObject.Find ("SceneAudio").GetComponent<AudioSource> ();
	}
	public override void PlayLoginBGAudio(){
		SceneAudios.clip = Resources.Load ("Login")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayBGAudio(int level){
		switch (level) {
		case 1:
			SceneAudios.clip = Resources.Load ("SwampBGM")as AudioClip;
			SceneAudios.Play ();
			SceneAudios.loop = true;
			break;
		case 2:
			SceneAudios.clip= Resources.Load ("SummerBGM")as AudioClip;
			SceneAudios.Play ();
			SceneAudios.loop = true;
			break;
		case 3:
			SceneAudios.clip = Resources.Load ("ForestBGM")as AudioClip;
			SceneAudios.Play ();
			SceneAudios.loop = true;
			break;
		}
	}
	public override void PlayButtonAudioA(){
		SceneAudios.clip = Resources.Load ("Button_01")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayButtonAudioB(){
		SceneAudios.clip = Resources.Load ("Button_02")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayEatAudio(){
		SceneAudios.clip = Resources.Load ("eat")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayPauseAudio(){
		SceneAudios.clip = Resources.Load ("Pause")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayDrinkAudio(){
		SceneAudios.clip = Resources.Load ("Drink")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayFinishAudio(){
		SceneAudios.clip = Resources.Load ("Finish")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlaySelectAudio(){
		SceneAudios.clip = Resources.Load ("Select")as AudioClip;
		SceneAudios.Play ();
	}
	public override void PlayWriteBGMAudio(){
		SceneAudios.clip=Resources.Load ("WriteBGM")as AudioClip;
		SceneAudios.Play ();
		SceneAudios.loop = true;
	}
	public override void PlayDeadBGAudio(){
		SceneAudios.clip=Resources.Load ("DBGM")as AudioClip;
		SceneAudios.Play ();
		SceneAudios.loop = true;
	}

}
