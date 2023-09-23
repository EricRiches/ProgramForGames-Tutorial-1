using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static GameContorl _gameControls;
    public static void Init(Player myPlayer)
    {
        _gameControls = new GameContorl();

        _gameControls.Permanent.Enable();

        _gameControls.InGame.Movement.performed += jeff =>
        {
            myPlayer.SetMovementDirection(jeff.ReadValue<Vector3>());
        };
    }

    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();

        _gameControls.UI.Disable();
    }
    public static void SetUiControls()
    {
        _gameControls.UI.Enable();

        _gameControls.InGame.Disable();
    }
}
