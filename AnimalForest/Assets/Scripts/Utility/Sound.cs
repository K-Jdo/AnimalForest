// K.Joudo. 2020
using UnityEngine;

// 音を鳴らすクラス
public class Sound : SingletonMonoBehaviour<Sound>
{
    [SerializeField] AudioClip[] clips = default;
    AudioSource source;

    public enum SoundName
    {
        // ここに鳴らす効果音の名前を書いていく
    }

    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundName name)
    {
        source.PlayOneShot(clips[(int)name]);
    }
}
