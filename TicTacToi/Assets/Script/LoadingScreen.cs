using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;

    [SerializeField]
    private GameObject loading_Bar_Holder;

    [SerializeField]
    private Image loading_Bar_Progress;

    private float progress_Value = 1.1f;
    public float progress_Multiplier_1 = 0.5f;
    public float progress_Multiplier_2 = 0.07f;

    public float load_Level_Time = 2f;

    void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingSomeLevel());
    }

    void Update()
    {
        ShowLoadingScreen();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        loading_Bar_Holder.SetActive(true);

        progress_Value = 0f;

        //Time.timeScale = 0f;

    }

    public void ShowLoadingScreen()
    {
        if(progress_Value<1f)
        {
            progress_Value += progress_Multiplier_1 * progress_Multiplier_2;
            loading_Bar_Progress.fillAmount = progress_Value;
            
            //The Loading Bar Has Finished
            if(progress_Value>=1f)
            {
                progress_Value = 1.1f;

                loading_Bar_Progress.fillAmount = 0f;

                loading_Bar_Holder.SetActive(false);

                SceneManager.LoadScene("HomePage");
            }
        }//if Progress Value<1
    }

    IEnumerator LoadingSomeLevel()
    {
        yield return new WaitForSeconds(load_Level_Time);

        LoadLevel("HomePage");

        //LoadLeveAsync("HomePage");
    }

    /*public void LoadLeveAsync(string levelName)
    {
        StartCoroutine(LoadAsynchronously(levelName));
    }

    IEnumerator LoadAsynchronously(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        loading_Bar_Holder.SetActive(true);

        //While The Opration IS Not Done
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;

            loading_Bar_Progress.fillAmount = progress;

            if(progress>=1f)
            {
                loading_Bar_Holder.SetActive(false);
            }
            yield return null;
        }
    }*/

}//class
