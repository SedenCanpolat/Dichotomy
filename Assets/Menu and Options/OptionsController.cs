using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	
	[Header("Assignables")]
	public AudioSource musicSource;

	public Slider masterSlider;
	public Slider musicSlider;

	private void Start()
	{
		if(PlayerPrefs.HasKey("MasterVolume") == false)
		{
			PlayerPrefs.SetFloat("MasterVolume", 1f);
		}
		else
		{
			masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
			AudioListener.volume = masterSlider.value;
		}

		if (PlayerPrefs.HasKey("MusicVolume") == false)
		{
			PlayerPrefs.SetFloat("MusicVolume", 1f);
		}
		else
		{
			musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
			musicSource.volume = musicSlider.value;
		}
	}


	private bool isFullscreen = true;

	public void ToggleFullscreen()
	{
		isFullscreen = !isFullscreen;
		Screen.fullScreen = isFullscreen;
	}
}
