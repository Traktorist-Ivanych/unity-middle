using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip[] stepsClips;
    [SerializeField] private AudioClip swordAttack;
    [SerializeField] private AudioClip takeDamage;
    [SerializeField] private AudioClip death;
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        playerHealth.TakeDamageEvent += TakeDamageSound;
        playerHealth.DeathEvent += DeathSound;
    }

    public void PlayStepAudio()
    {
        PlaySound(stepsClips[Random.Range(0, stepsClips.Length - 1)]);
    }

    public void PlaySwordAttackAudio()
    {
        PlaySound(swordAttack);
    }

    public void TakeDamageSound()
    {
        PlaySound(takeDamage);
    }

    public void DeathSound()
    {
        PlaySound(death);
    }

    private void PlaySound(AudioClip audioClip)
    {
        playerAudioSource.pitch = Random.Range(0.9f, 1.1f);
        playerAudioSource.PlayOneShot(audioClip);
    }
}
