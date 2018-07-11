using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

    public AudioClip mainMusic;

    private AudioSource source;


	void Awake () {
        source = GetComponent<AudioSource>();
	}

    void onLevelWasLoaded (int level) {
     //   if (level == 1)
      //  {
            source.clip = mainMusic;
            source.Play();
      //  }
	}
}
