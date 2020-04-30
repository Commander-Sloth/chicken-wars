using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour
{
	public static AudioClip projectileBoom;
    static AudioSource audioSrc;

	// public void playBoom()
	// {
	// 	Boom.Play();
	// }

    // Start is called before the first frame update
    void Start()
    {
        projectileBoom = Resources.Load<AudioClip>("Boom");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "boomSound":
            audioSrc.PlayOneShot(projectileBoom);
            break;
        }
    }
}
// https://www.youtube.com/watch?v=8pFlnyfRfRc