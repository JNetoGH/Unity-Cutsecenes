using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneRaplayer : MonoBehaviour
{

    [SerializeField] private bool _replayAfterWait = true;
    [SerializeField] private float _amountOfTimeToWait = 30f;
    private Button _resetButton;
    private float _timer = 0f;

    private void Start()
    {
        _timer = 0f;
        // assigns the button event
        FindObjectOfType<Button>().onClick.AddListener(ResetCutscene);
    }
    
    private void Update()
    {
        if (!_replayAfterWait)
            return;

        _timer += Time.deltaTime;
        if (_timer >= _amountOfTimeToWait)
            ResetCutscene();
    }

    /// <summary>
    /// Also called by the button on click event.
    /// </summary>
    public void ResetCutscene()
    {
        Scene cur = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cur.buildIndex);
    }
    
}
