using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioMixerGroup MusicMixer;
    public AudioMixerGroup SoundsMixer;

    [Header("����")]
    public Button soundButton;      // ������ �����
    public TMP_Text soundButtonText; // ����� �� ������ �����

    [Header("������")]
    public Button musicButton;      // ������ ������
    public TMP_Text musicButtonText; // ����� �� ������ ������


    private Color activeColor = Color.white;
    private Color inactiveColor;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#9C9C9C", out inactiveColor);

        // ��������� ����������� �������
        soundButton.onClick.AddListener(ToggleSound);
        musicButton.onClick.AddListener(ToggleMusic);

        bool isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        bool isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        // ��������������� ��������� �� PlayerPrefs
        UpdateSoundUI(isSoundOn);
        if (!isSoundOn)
            SoundsMixer.audioMixer.SetFloat("soundsVolume", -80);

        UpdateMusicUI(isMusicOn);
        if (!isMusicOn)
            MusicMixer.audioMixer.SetFloat("musicVolume", -80);




    }

    // ===== ���� =====
    private void ToggleSound()
    {
        bool isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        isSoundOn = !isSoundOn; // ����������� ���������
        if (isSoundOn)
            SoundsMixer.audioMixer.SetFloat("soundsVolume", 0);
        else
            SoundsMixer.audioMixer.SetFloat("soundsVolume", -80);
        PlayerPrefs.SetInt("SoundOn", isSoundOn ? 1 : 0);
        UpdateSoundUI(isSoundOn);
    }

    private void UpdateSoundUI(bool isOn)
    {
        soundButtonText.text = isOn ? "���" : "����";
        soundButtonText.color = isOn ? activeColor : inactiveColor;
    }

    // ===== ������ =====
    private void ToggleMusic()
    {
        bool isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        isMusicOn = !isMusicOn; // ����������� ���������
        if (isMusicOn)
            MusicMixer.audioMixer.SetFloat("musicVolume", -15);
        else
            MusicMixer.audioMixer.SetFloat("musicVolume", -80);
        PlayerPrefs.SetInt("MusicOn", isMusicOn ? 1 : 0);
        UpdateMusicUI(isMusicOn);
    }

    private void UpdateMusicUI(bool isOn)
    {
        musicButtonText.text = isOn ? "���" : "����";
        musicButtonText.color = isOn ? activeColor : inactiveColor;
    }
}
