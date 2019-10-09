using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager :BaseManager
{
    public AudioManager(GameFacade gameFacade) : base(gameFacade) { }
    private const string Sound_Prefix = "Sounds/";
    public const string Sound_Alert = "Alert";
    public const string Sound_ArrowShoot = "ArrowShoot";
    public const string Sound_Bg_Moderate = "Bg(Moderate)";
    public const string Sound_Bg_Fast = "BG(fast)";
    public const string Sound_ButtonClick = "ButtonClick";
    public const string Sound_Miss = "Miss";
    public const string Sound_ShootPerson = "ShootPerson";
    public const string Sound_Timer = "Timer";
    public const string Sound_Bg = "Music";
    public const string Sound_windy = "Windy";

    private AudioSource bgAudioSourceMap;
    private AudioSource normalAudioSource;
    private AudioSource BGSourceUI;
    public override void OnInit()
    {
        GameObject audioSource = new GameObject("AudioSource(GameObject)");
        bgAudioSourceMap = audioSource.AddComponent<AudioSource>();
        normalAudioSource = audioSource.AddComponent<AudioSource>();
        BGSourceUI = audioSource.AddComponent<AudioSource>();

        PlaySound(BGSourceUI,LoadSound(Sound_Bg),0.3f,true);
 
    }
    public void PlaySoundBGUI(string soundName) {
        PlaySound(BGSourceUI, LoadSound(soundName),1f,true );
    }
    public void PlayNormalSound(string soundName ) {
        PlaySound(normalAudioSource, LoadSound(soundName),1f);
    }
    private void PlaySound(AudioSource audiosource, AudioClip audioClip,float SoundVolume, bool loop = false) {
        audiosource.clip = audioClip;
        audiosource.volume = SoundVolume;
        audiosource.loop = loop;
        audiosource.Play();
    }
    private AudioClip LoadSound(string soundName) {
       return Resources.Load<AudioClip>(Sound_Prefix + soundName);
    }
}
