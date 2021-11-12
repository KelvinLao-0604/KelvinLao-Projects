using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ScoreKeeper : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one ScoreKeeper object, so we just store it in
    /// a static field so we don't have to call FindObjectOfType(), which is expensive.
    /// </summary>
    public static ScoreKeeper Singleton;


    /// <summary>
    /// Current score
    /// </summary>
    public int Score;

    public int MaxScore = 30;

    public GameObject VictoryScreen;

    private bool won = false;


    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoreDisplay;

    /// <summary>
    /// Initialize Singleton and ScoreDisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        ScorePointsInternal(0);
    }

    /// <summary>
    /// Add points to the score
    /// </summary>
    /// <param name="points">Number of points to add to the score; can be positive or negative</param>
    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);
    }
    /// <summary>
    /// Internal, non-static, version of ScorePoints
    /// </summary>
    /// <param name="delta"></param>
    private void ScorePointsInternal(int delta)
    {
        if (delta < 0)
        {
            Score--;
        }
        else if (delta > 0)
        {
            Score++;
        }
        scoreDisplay.text = "Score: " + Score;
    }

    private void Update()
    {
        if (Score >= MaxScore && won == false)
        {
            Instantiate(VictoryScreen, new Vector3(0, 0, 0), Quaternion.identity);
            won = true;
            GameObject thePlayer = GameObject.Find("Player");
            CharacterMovement PlayerMovement = thePlayer.GetComponent<CharacterMovement>();
            GameObject spawnerObject = GameObject.Find("EnemySpawner");
            Spawner spawner = spawnerObject.GetComponent<Spawner>();
            PlayerMovement.won = true;
            spawner.won = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}
