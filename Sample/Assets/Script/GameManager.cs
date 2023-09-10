using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject Light;

    public Animator transition;
    public float transitionTime = 1f;

    public GameObject pauseMenuWindow;

    public GameObject howToPlayMenu;

    public GameObject finishGameScene;

    public GameObject MainMenuActivity;


    void Start() {
        Invoke("Lighting", 2f);
    }

    void Update() {
        if(Input.GetKey(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pauseMenuWindow.SetActive(true);
        }
    }

    public void EndGame() {
        if(gameHasEnded == false) {
            gameHasEnded =  true;
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart() {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("GamePlay"));
    }

    public void NewGame() {
        StartCoroutine(LoadLevel("GamePlay"));
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        finishGameScene.SetActive(false);
        StartCoroutine(LoadLevel("MainMenu"));
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Lighting() {
        Light.SetActive(true);
        MainMenuActivity.SetActive(true);
    }

    public void ResumeMenu() {
        Time.timeScale = 1f;
        pauseMenuWindow.SetActive(false);
    }

    public void HowToPlayMenu() {
        howToPlayMenu.SetActive(true);
    }

    public void HowToPlayBackButton() {
        howToPlayMenu.SetActive(false);
    }

    public void FinishGame() {
        StartCoroutine(EndScene());
    }

    IEnumerator LoadLevel(string levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator EndScene() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime + 1f);

        finishGameScene.SetActive(true);
    }
}
