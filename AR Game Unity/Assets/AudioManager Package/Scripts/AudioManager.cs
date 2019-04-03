using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public static AudioManager SharedInstance;

    public AudioMixer mixer;

    [Header("Add all sounds here")]
    public List <AudioClip> audioClips;

    private void Awake()
    {
        SharedInstance = this;
    }


    public void PlayClip(int clipIndex) 
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {

            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name =audioClips[clipIndex].name;
            ObjectPooler.SharedInstance.activeObjects.Add(audioObject);


            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().Play();
            audioObject.GetComponent<SetInactiveAfterTime>().enabled = true;
            //Destroy after done playing
            // StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }

    //Overload 1
    public void PlayClip(int clipIndex, float volume)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;
            ObjectPooler.SharedInstance.activeObjects.Add(audioObject);


            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().Play();
            audioObject.GetComponent<AudioSource>().volume = volume;

            audioObject.GetComponent<SetInactiveAfterTime>().enabled = true;

            //Destroy after done playing
            //  StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }

    //Overload 2
    public void PlayClip(int clipIndex, float volume,  bool loop)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
          
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;

            ObjectPooler.SharedInstance.activeObjects.Add(audioObject);
            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().loop = loop;
            audioObject.GetComponent<AudioSource>().volume = volume;

            audioObject.GetComponent<AudioSource>().Play();

            audioObject.GetComponent<SetInactiveAfterTime>().enabled = false;

            //Destroy after done playing
            if (!loop)
            {
              //  StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
            }
        }       
    }

    //Overload 4
    public void PlayClip(int clipIndex, float volume, bool loop, float pitch)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            ObjectPooler.SharedInstance.activeObjects.Add(audioObject);
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;


            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().loop = loop;
            audioObject.GetComponent<AudioSource>().pitch = pitch;
            audioObject.GetComponent<AudioSource>().volume = volume;
            

            audioObject.GetComponent<AudioSource>().Play();

            //Destroy after done playing
            if (!loop)
            {
                //StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
            }
        }
    }

    // Overloads with OUTPUT 
    public void PlayClip(int clipIndex, string mixerGroup)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;

            //set the audioObject to active
            audioObject.SetActive(true);

            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups(mixerGroup)[0];
            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];            
            audioObject.GetComponent<AudioSource>().Play();

            //Destroy after done playing
           // StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }
    public void PlayClip(int clipIndex, string mixerGroup, bool loop)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;

            //set the audioObject to active
            audioObject.SetActive(true);

            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups(mixerGroup)[0];
            audioObject.GetComponent<AudioSource>().loop = loop;
            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().Play();

            //Destroy after done playing
            //StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
