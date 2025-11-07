using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public struct SceneMusic { public string sceneName; public AudioClip clip; }

    [Header("Assign in Inspector")]
    [SerializeField] AudioSource musicSource;   // drag the AudioSource here
    [SerializeField] List<SceneMusic> perScene = new List<SceneMusic>();
    [SerializeField] AudioClip defaultClip;     // optional fallback

    [Header("Options")]
    [Range(0f,1f)] public float volume = 0.8f;
    public float crossfadeSeconds = 0.8f;

    Dictionary<string, AudioClip> map;

    void Awake()
    {
        // keep exactly one across scenes
        var existing = FindObjectsOfType<AudioManager>();
        if (existing.Length > 1) { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);

        if (!musicSource) musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.spatialBlend = 0f; // 2D
        musicSource.volume = 0f;

        map = new Dictionary<string, AudioClip>();
        foreach (var m in perScene)
            if (!string.IsNullOrEmpty(m.sceneName) && m.clip) map[m.sceneName] = m.clip;

        SceneManager.sceneLoaded += (_, __) => PlayForScene(SceneManager.GetActiveScene().name);
        // start for the current scene in editor
        PlayForScene(SceneManager.GetActiveScene().name, instant:true);
    }

    void OnDestroy() => SceneManager.sceneLoaded -= (_, __) => {};

    public void PlayForScene(string sceneName, bool instant = false)
    {
        map.TryGetValue(sceneName, out var clip);
        if (!clip) clip = defaultClip;
        if (!clip) return;

        if (musicSource.clip == clip && musicSource.isPlaying) return;

        if (instant || crossfadeSeconds <= 0.01f)
        {
            musicSource.clip = clip;
            musicSource.volume = volume;
            musicSource.Play();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Crossfade(clip));
        }
    }

    System.Collections.IEnumerator Crossfade(AudioClip next)
    {
        float t = 0f, d = crossfadeSeconds;
        float start = musicSource.volume;
        while (t < d) { t += Time.unscaledDeltaTime; musicSource.volume = Mathf.Lerp(start, 0f, t/d); yield return null; }

        musicSource.clip = next;
        if (!musicSource.isPlaying) musicSource.Play();

        t = 0f;
        while (t < d) { t += Time.unscaledDeltaTime; musicSource.volume = Mathf.Lerp(0f, volume, t/d); yield return null; }
        musicSource.volume = volume;
    }
}
