using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    private AudioSource audioSource;

    private static PlayBGM instance = null;
    public static PlayBGM Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<AudioSource>() == null) //if object does not have AudioSource component
        {
            gameObject.AddComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().playOnAwake = false;
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        }
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = Resources.Load<AudioClip>("Audio/bgm_heaven");
        //audioSource.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
            else
            {
                audioSource.Stop();
            }
        }

    }
}
