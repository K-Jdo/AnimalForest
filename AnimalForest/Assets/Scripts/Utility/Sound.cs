// K.Joudo. 2020
using UnityEngine;

// 音を鳴らすクラス
public class Sound : SingletonMonoBehaviour<Sound>
{
    [SerializeField] AudioClip[] clips = default;
    AudioSource source;

    public enum SoundName
    {
        cansel,
        damage,
        death,
        decieded,
        karuizawa,
        spawn,
        tree_break
    }

    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    public void PlaySound(SoundName name)
    {
        source.PlayOneShot(clips[(int)name]);
    }
}
