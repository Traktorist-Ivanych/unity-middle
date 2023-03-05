using UnityEngine;
using UnityEngine.Audio;

public class SoundsSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup masterMixer;
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup effectsMixer;
    [SerializeField] private AudioMixerGroup uIMixer;

    public void ChangeMasterMixerVolume(float volume)
    {
        masterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeMusicMixerVolume(float volume)
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeEffectsMixerVolume(float volume)
    {
        effectsMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeUIMixerVolume(float volume)
    {
        uIMixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));
    }
}
