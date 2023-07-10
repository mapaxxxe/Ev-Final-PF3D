using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
  
    public static System.Action<string> OnStateChange;
    [SerializeField] private string initialState;
    private string actualState;


    private void OnEnable()
    {
        GameManager.OnStateChange += HandleStateChange;
    }

    private void OnDisable()
    {
        GameManager.OnStateChange -= HandleStateChange;
    }



    private void Start()
    {
        SwitchState(initialState);
    }




    public void SwitchState(string newState)
    {
        if (actualState == newState) return;
        actualState = newState;

        OnStateChange?.Invoke(newState);
    }

    public void Dead()
    {
        GameManager.instance.SwitchState("Game Over");
    }

    private void HandleStateChange(string state)
    {
        if (state == "Gameplay")
	{
            FindObjectOfType<player>().canmove = true;
        }

	else if (state == "Game Over")
	{
            // Aquí asignamos todo el funcionamiento de cuando el estado sea Game Over
        }

	else if (state == "Victory")
{
            // Aquí asignamos todo el funcionamiento de cuando el estado sea Victory
        }
    }

}




