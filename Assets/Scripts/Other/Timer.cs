using UnityEngine;

public class Timer : MonoBehaviour
{
    // Fields
    [SerializeField] private float startingTime;
    public float StartingTime
    {
        get { return startingTime; }
        private set { startingTime = value; }
    }

    public float _timeLeft { get; private set; }

    // Basic methods
    void Start()
    {
        ResetTimer();
    }
    void Update()
    {
        if (_timeLeft > 0)
            _timeLeft -= Time.deltaTime;
    }

    // User methods
    public bool IsElapsed() { return _timeLeft <= 0; }
    public void ResetTimer() { _timeLeft = startingTime; }
    public void ResetTimer(float newTime)
    {
        startingTime = newTime;
        _timeLeft = startingTime;
    }
}
