using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToggleFullscreenScript : MonoBehaviour {
    public Toggle FullscreenToggle;
    public Dropdown ResolutionDropdown;
    int select;
    bool isFullscreen;

    void Start() {
        FullscreenToggle = FullscreenToggle.GetComponent<Toggle>();
        FullscreenToggle.isOn = false;
        ResolutionDropdown.onValueChanged.AddListener(delegate
        {
            ResolutionDropdownValueChangedHandler(ResolutionDropdown);
        });
        }
        void Destroy() {
            ResolutionDropdown.onValueChanged.RemoveAllListeners();
        }
        private void ResolutionDropdownValueChangedHandler(Dropdown target) {
        Debug.Log("selected: " + target.value);
        select = target.value;
    }
    public void SetDropdownIndex(int index)
    {
        
        ResolutionDropdown.value = index;
      
    }
        void Update () {
        if (FullscreenToggle.isOn == true){
            isFullscreen = true;
            Debug.log("Fullscreen is ON");
            Screen.fullScreen = true;
        }
            if (FullscreenToggle.isOn == false)
            {
            Screen.fullScreen = false;
            isFullscreen = false;
                Debug.log("Fullscreen is OFF");
        }
        if (select == 2)
        {
            if (isFullscreen == true)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            if (isFullscreen == false)
            {
                Screen.SetResolution(1920, 1080, false);
            }
        }
        if (select == 1)
        {
            if (isFullscreen == true)
            {
                Screen.SetResolution(1440, 900, true);
            }
            if (isFullscreen == false)
            {
                Screen.SetResolution(1440, 900, false);
            }
        }
        if (select == 0)
        {
            if (isFullscreen == true)
            {
                Screen.SetResolution(640, 480, true);
            }
            if (isFullscreen == false)
            {
                Screen.SetResolution(640, 480, false);
            }
        }

    }
    }
