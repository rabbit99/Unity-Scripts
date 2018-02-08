using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingPage : MonoBehaviour {

    public GameObject loadPage;
	public Text loadText;
    public Slider loadBar;
	// Use this for initialization
	void Start () {
        //直式
        if(Application.loadedLevel == 0)
            Screen.orientation = ScreenOrientation.Portrait;
	}

    //UI
    public void Btn_LoadARScene() {
        PlayerPrefs.SetInt("SceneMode", 0);
        StartClick("Home_AR3D", ScreenOrientation.LandscapeLeft);
    }
    public void Btn_LoadRoomScene() {
        PlayerPrefs.SetInt("SceneMode", 1);
        StartClick("Home_AR3D", ScreenOrientation.LandscapeLeft);
    }
    public void Btn_LoadGameScene(){
        StartClick("Home_ARGame", ScreenOrientation.Portrait);
    }
    public void Btn_MainScene(){
        StartClick("Home_Main", ScreenOrientation.Portrait);
    }
    //
    void StartClick(string sceneName, ScreenOrientation orientation)
    {
        Screen.orientation = orientation;
		loadPage.SetActive(true);
		StartCoroutine(StartLoading(sceneName));
        
    }
    IEnumerator StartLoading(string sceneName)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = Application.LoadLevelAsync(sceneName);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
	void SetLoadingPercentage(int persent){
		loadText.text = persent.ToString() + "%";
		loadBar.value = (float)(persent / 100.00f);
	}
}
