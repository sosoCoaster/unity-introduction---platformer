using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class audioLoop : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mainLoop;
    [SerializeField] private AudioClip winLoop;
    [SerializeField] private float startLoop;
    [SerializeField] private float endLoop;
    [SerializeField] private Volume effects;
    private float tempo = 0.4f;
    private float timeTarget;
    // Start is called before the first frame update
    public void winAudioChange()
    {
        audioSource.Stop();
        audioSource.clip = winLoop;
        audioSource.time = startLoop;
        audioSource.Play();
        timeTarget = audioSource.time + tempo;
    }
    public void mainAudioChange()
    {
        audioSource.Stop();
        audioSource.clip = mainLoop;
        audioSource.time = 1f;
        audioSource.Play();
        effects.profile.TryGet(out Vignette vg);
        vg.intensity.value = 0f;
        vg.smoothness.value = 0f;
    }
    void Start()
    {
        mainAudioChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.clip == winLoop)
        {
            effects.profile.TryGet(out Vignette vg);
            vg.intensity.value = 0f;
            vg.smoothness.value = 0f;
            if (audioSource.time > endLoop)
            {
                audioSource.time = startLoop;
                timeTarget = audioSource.time + tempo;
            }
            if (audioSource.time > 33.5f)
                {
                    vg.intensity.value = 0.3f;
                    vg.smoothness.value = 0.5f - ((audioSource.time - timeTarget) * 0.5f / tempo);
                }
                Debug.Log(1f - ((audioSource.time - timeTarget) * 0.5f / tempo));
            if (audioSource.time >= timeTarget)
            {
                timeTarget = audioSource.time + tempo;
            }
        }
    }
}
