using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;

public class MovieTextures : MonoBehaviour,
                                            ITrackableEventHandler
{
    public MovieTexture movie;
    private RawImage rawImage;
    public bool EnableLogging = true;

    //  public AudioSource soundTest;
    private TrackableBehaviour mTrackableBehaviour;

    // Use this for initialization
    void Start () {
        rawImage = GetComponent<RawImage>();
        rawImage.enabled = true;
        rawImage.texture = movie;


        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        //this.gameObject.GetComponent<Renderer>().material.mainTexture = movie;
        //soundTest.clip = movie.audioClip;

        //soundTest.Play();
        //movie.Play();
        //movie.loop = true;


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void PlayVideo()
    {
        Debug.Log("Play video....START");
        movie.Play();
        Debug.Log("Play video....END");
    }

    private void StopVideo()
    {
        Debug.Log("Pause video....START");
        movie.Pause();
        Debug.Log("Pause video....STOP");
    }


    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Target Found");
            PlayVideo();
        }
        else
        {
            Debug.Log("Target Lost");
            StopVideo();
        }
    }

}
