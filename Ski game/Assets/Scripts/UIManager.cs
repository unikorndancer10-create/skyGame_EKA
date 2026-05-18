using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup screenOverlay;
    [SerializeField] private float fadeSpeed = 2;
    [SerializeField] private GameObject raceOverPanel;
    [SerializeField] private int nextLevelIndex = 1;
    //[SerializeField] private GameObject buttonsPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenOverlay.gameObject.SetActive(true);
        //buttonsPanel.gameObject.SetActive(false);
        StartCoroutine(FadeOutOverlay());
    }

    private void OnEnable()
    {
        FinishGate.StopRace += OnRaceFinished;
    }

    private void OnDisable()
    {
        FinishGate.StopRace -= OnRaceFinished;
    }
    
    private void OnRaceFinished()
    {
        raceOverPanel.SetActive(true);
        //buttonsPanel.SetActive(true);

    }
  

    private IEnumerator FadeOutOverlay()
    {
        while(screenOverlay.alpha > 0)
        {
            screenOverlay.alpha-= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    private IEnumerator FadeInOverlay()
    {
        while (screenOverlay.alpha < 1)
        {
            screenOverlay.alpha+= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    public void Restart()
    {
        StartCoroutine(ResrartCoroutine());
    }
    private IEnumerator ResrartCoroutine ()
    {
       yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void NextLevel()
    {
        StartCoroutine(NextlevelCoruotine());
    }

    private IEnumerator NextlevelCoruotine()
    {
        yield return StartCoroutine(FadeInOverlay());
            SceneManager.LoadScene(nextLevelIndex);
    }

    public void Quit()
    {
        StartCoroutine (QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
