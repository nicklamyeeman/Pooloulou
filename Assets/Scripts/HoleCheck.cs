using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCheck : MonoBehaviour
{
    [SerializeField]
    private MyGameManager gameManager;

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Yellow"))
        {
            Destroy(hit.gameObject);
            SetBallTypes(hit, "Red");
            HandlePoints(hit);
        }
        if (hit.gameObject.CompareTag("Red"))
        {
            Destroy(hit.gameObject);
            SetBallTypes(hit, "Yellow");
            HandlePoints(hit);
        }
        if (hit.gameObject.CompareTag("CueBall"))
        {
            gameManager.respawnBall();
            gameManager.Fault = true;
        }
        if (hit.gameObject.CompareTag("Black"))
        {
            if (gameManager.PlayerTurn().Balls != 7)
                gameManager.endGame(gameManager.PlayerWaiting());
            else
                gameManager.endGame(gameManager.PlayerTurn());
        }
    }

    private void SetBallTypes(Collision hit, string type)
    {
        if (gameManager.PlayerTurn().BallType == "none")
        {
            gameManager.PlayerTurn().BallType = hit.gameObject.tag;
            gameManager.PlayerWaiting().BallType = type;

            print("name: " + MasterManager.Players[0].Name + " type: " + MasterManager.Players[0].BallType);
            print("name: " + MasterManager.Players[1].Name + " type: " + MasterManager.Players[1].BallType);
        }

    }

    private void HandlePoints(Collision hit)
    {
        int currentPlayer = gameManager.Turn;
        int waitingPlayer = currentPlayer * -1 + 1;

        if (gameManager.PlayerTurn().BallType == hit.gameObject.tag)
        {
            print("GOOD SIDE");
        }
        else
        {
            print("FAUTE");
            gameManager.Fault = true;
        }
    }

}
