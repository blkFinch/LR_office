using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	static MusicManager instance = null;

	// Singleton
	private void Awake()
    {
        Debug.Log("Music Player Awake " + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Dupe musicplayer destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
	
	
}
