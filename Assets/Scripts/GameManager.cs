using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour
{

    public static bool gameHasEnded;

    public Rotator rotator;
    public Spawner spawner;
	public GameObject replayMenuCanvas;

    public AudioSource playAudio;
    public AudioSource pauseAudio;

    private Animator animator;

    private void Start()
    {
        gameHasEnded = false;
        playAudio.PlayDelayed(0.83f);
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void EndGame()
    {
        if (gameHasEnded)
        {
            return;
        }

        animator.SetTrigger("EndGame");
        rotator.enabled = false;
		spawner.gameObject.SetActive(false);

        playAudio.Stop();
        pauseAudio.PlayDelayed(1f);
        gameHasEnded = true;
    }

	public void ShowReplayMune() {
		int highScore = PlayerPrefs.GetInt("HighScore");
		if (Score.pinCount > highScore) {
			PlayerPrefs.SetInt("HighScore", Score.pinCount);
		}
		replayMenuCanvas.SetActive(true);
	}

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RotatorSlowPlay()
    {
        rotator.enabled = true;
        Time.timeScale = 0.1f;
    }
}
