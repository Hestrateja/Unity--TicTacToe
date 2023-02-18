using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicTacToe : MonoBehaviour
{
    public TextMeshProUGUI[] gridSpaces;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    private string currentPlayer;
    private int[] boardState;

    void Start()
    {
        boardState = new int[9];
        currentPlayer = "X";
    }

    public void ButtonClick(int spaceIndex)
    {
        if (boardState[spaceIndex] == 0)
        {
            boardState[spaceIndex] = (currentPlayer == "X") ? 1 : -1;
            gridSpaces[spaceIndex].text = currentPlayer;
            CheckForWin();
            ChangePlayer();
        }
    }

    void CheckForWin()
    {
        if (Mathf.Abs(boardState[0] + boardState[1] + boardState[2]) == 3 ||
            Mathf.Abs(boardState[3] + boardState[4] + boardState[5]) == 3 ||
            Mathf.Abs(boardState[6] + boardState[7] + boardState[8]) == 3 ||
            Mathf.Abs(boardState[0] + boardState[3] + boardState[6]) == 3 ||
            Mathf.Abs(boardState[1] + boardState[4] + boardState[7]) == 3 ||
            Mathf.Abs(boardState[2] + boardState[5] + boardState[8]) == 3 ||
            Mathf.Abs(boardState[0] + boardState[4] + boardState[8]) == 3 ||
            Mathf.Abs(boardState[2] + boardState[4] + boardState[6]) == 3)
        {
            GameOver(currentPlayer + " wins!");
        }
        else if (boardState[0] != 0 && boardState[1] != 0 && boardState[2] != 0 &&
                 boardState[3] != 0 && boardState[4] != 0 && boardState[5] != 0 &&
                 boardState[6] != 0 && boardState[7] != 0 && boardState[8] != 0)
        {
            GameOver("Tie game!");
        }
    }

    void ChangePlayer()
    {
        currentPlayer = (currentPlayer == "X") ? "O" : "X";
    }

    void GameOver(string message)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = message;
    }

    public void PlayAgain()
    {
        boardState = new int[9];
        currentPlayer = "X";
        gameOverPanel.SetActive(false);
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            gridSpaces[i].text = "";
        }
    }
}