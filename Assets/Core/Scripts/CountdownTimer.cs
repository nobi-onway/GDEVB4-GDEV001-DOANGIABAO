using System;

public class CountdownTimer
{
    private float _duration;
    private float _elapsedTime;
    private bool _stopped;

    public CountdownTimer(float duration)
    {
        _duration = duration;
        _elapsedTime = 0f;
        _stopped = false;
    }

    public void Tick(float deltaTime, Action onTimeUp)
    {
        if (_stopped) return;

        _elapsedTime += deltaTime;

        if (IsFinished())
        {
            onTimeUp?.Invoke();
            _stopped = true;
        }
    }

    public void Stop() => _stopped = true;
    public void Resume() => _stopped = false;

    public bool IsFinished()
    {
        return _elapsedTime >= _duration;
    }

    public void Reset()
    {
        _elapsedTime = 0f;
        _stopped = false;
    }
}