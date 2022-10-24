using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadUI : MonoBehaviour
{
    public AudioSource DeadUIAudio;
    public AudioClip DeadUIClip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeadAudio()
    {
        DeadUIAudio.PlayOneShot(DeadUIClip);
    }
}
