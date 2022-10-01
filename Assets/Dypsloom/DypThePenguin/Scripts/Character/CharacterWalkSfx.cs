using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkSfx : MonoBehaviour
{
    
    [Tooltip("Audio source for steps sfx")]
    [SerializeField] protected AudioSource m_WalkSource;

    [Tooltip("List of audio files for steps")]
    [SerializeField] protected AudioClip[] m_StepSounds;

    private bool isWalking = false;
    private int lastIndex = -1;

    // Update is called once per frame
    void Update()
    {
        if (m_StepSounds.Length < 1) { return; }

        if (isWalking && !m_WalkSource.isPlaying) {
            var rand = 0;

            if (m_StepSounds.Length > 1) {
                do {
                    rand = (int) Random.Range(0, m_StepSounds.Length - 1);
                } while (rand == lastIndex);

                lastIndex = rand;
            }

            m_WalkSource.clip = m_StepSounds[rand];
            m_WalkSource.Play();
        }
        else if (!isWalking && m_WalkSource.isPlaying) {
            m_WalkSource.Stop();
        }
    }

    public void Play() {
        isWalking = true;
    }

    public void Stop() {
        isWalking = false;
    }
}
