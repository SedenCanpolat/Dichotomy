using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsController : MonoBehaviour
{
	#nullable enable

	[Header("Assignables")]	
	[SerializeField] private AudioSource? musicSource;

	[SerializeField] private Slider masterSlider;
	[SerializeField] private Slider musicSlider;
	[SerializeField] private TextMeshProUGUI masterSlider_value;
	[SerializeField] private TextMeshProUGUI musicSlider_value;

	private bool isFullscreen = true;

	[Header("Debug")]
	[SerializeField] private float masterAudioVolume;

	private void Start()
	{
		InitializeAudio();
		LoadAudio();		
		masterAudioVolume = AudioListener.volume;
		MenuController.Kronos(1);
	}

	private void InitializeAudio()
	{
		if (PlayerPrefs.HasKey("Master_Volume") == false)
		{
			PlayerPrefs.SetFloat("Master_Volume", 1f);
		}
		
		if (PlayerPrefs.HasKey("Music_Volume") == false)
		{
			PlayerPrefs.SetFloat("Music_Volume", 1f);
		}		
	}

	public void SaveMasterAudio()
	{
		masterSlider_value.text = (masterSlider.value * 100).ToString("0");
		PlayerPrefs.SetFloat("Master_Volume", masterSlider.value);	
		LoadAudio();
	}
	public void SaveMusicAudio()
	{
		musicSlider_value.text = (musicSlider.value * 100).ToString("0");
		PlayerPrefs.SetFloat("Music_Volume", musicSlider.value);
		LoadAudio();
	}

	public void LoadAudio()
	{
		masterSlider.value = PlayerPrefs.GetFloat("Master_Volume");
		AudioListener.volume = masterSlider.value;

		musicSlider.value = PlayerPrefs.GetFloat("Music_Volume");
		if (musicSource != null)
			musicSource.volume = musicSlider.value;
	}

	public void ToggleFullscreen()
	{
		isFullscreen = !isFullscreen;
		Screen.fullScreen = isFullscreen;
	}

}
