using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        Alarm,
        Food,
        Food2,
        Match,
        Background,
        LevelFailed,
        LevelComplete

    }

    [System.Serializable]
    public class Sound
    {
        public AudioClip Clip;
        public SoundType Type;
        [Range(0, 100)]
        public float Volume = 1f;
        [HideInInspector] 
        public AudioSource Source;
    }

    public static AudioManager Instance;

    public Sound[] AllSounds;

    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();
    private AudioSource _musicSource;

    private void Awake()
    {
        Instance = this;

        foreach(var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
        
    }

    public SoundType SelectedSound;
    // Update is called once per frame

    public void PlaySound(SoundType type)
    {
        if(!_soundDictionary.TryGetValue(type, out Sound s))
        {
            Debug.LogWarning("Sound type not found: " + type);
            return;
        }

        var soundObject = new GameObject($"Sound_{type}");
        var audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = s.Clip;
        audioSource.volume = s.Volume;
        audioSource.Play();
        Destroy(soundObject, s.Clip.length);
    }

    public void ChangeMusic(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound track))
        {
            Debug.LogWarning("Sound type not found: " + type);
            return;
        }

        if(track.Source == null)
        {
            var container = new GameObject("SoundTrackObj");
            _musicSource = container.AddComponent<AudioSource>();
            if(type == SoundType.Background)
            {
            _musicSource.loop = true;       
            }
        }
        _musicSource.clip = track.Clip;
        _musicSource.Play();
    }

}
