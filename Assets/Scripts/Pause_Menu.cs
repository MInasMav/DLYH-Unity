using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem; 
#endif
// above, that #if anf endif stuff is just unitys new style of input system i was trying to figure out why escape key wasnt exactly working
public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {

    }

    void Update()
    {
        if (EscapePressedThisFrame())
            TogglePause();
    }

    private bool EscapePressedThisFrame() //again, this is how i(GPT) setup how the game will register getting the escape key input
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
#else
        return Input.GetKeyDown(KeyCode.Escape);
#endif
    }

    private void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        if (pauseMenu) pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;        // ⬅️ pauses all AudioSources (except ones that ignore it)
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenu) pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;       // ⬅️ resume all audio
        isPaused = false;
    }

    //public void GoToMainMenu()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("MainMenu")
    //}

}