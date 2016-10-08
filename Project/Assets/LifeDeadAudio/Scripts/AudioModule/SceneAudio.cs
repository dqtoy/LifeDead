using UnityEngine;
using System.Collections;

public class SceneAudio : SceneAudioAbstract {
	private AudioClip ForestBGM;
	private AudioClip DBGM;
	private AudioClip Login;
	private AudioClip SummerBGM;
	private AudioClip SwampBGM;
	private AudioSource SceneAudios;
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
	public override void PlayDeadBGAudio(){
		SceneAudios.clip=Resources.Load ("DBGM")as AudioClip;
		SceneAudios.Play ();
		SceneAudios.loop = true;
	}
	public void Update(){
		if (Input.GetMouseButtonDown(0)) {
			PlayDeadBGAudio();
		}
	}
}
