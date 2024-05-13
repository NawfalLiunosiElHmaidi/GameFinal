using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string VideoFileName;
    
    void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        VideoPlayer VideoPlayer = GetComponent<VideoPlayer>();

        if (VideoPlayer) 
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, VideoFileName);
            Debug.Log(videoPath);
            VideoPlayer.url = videoPath;
            VideoPlayer.Play();
        }
    }
}
