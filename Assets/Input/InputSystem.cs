using System;
using UnityEngine;

public class InputSystem : MonoSingleton<InputSystem>
{
    public Vector2 CenterScreen => new Vector2(Screen.width / 2f, Screen.height / 2f);

    public event Action<Vector2> OnPointerDown;

    public void Update()
    {
        HandlePointerDown();
    }

    private void HandlePointerDown()
    {
        if(!Input.GetMouseButtonDown(0)) return;

        OnPointerDown?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}