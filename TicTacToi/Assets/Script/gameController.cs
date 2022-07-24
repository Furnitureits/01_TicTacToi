using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class gameController : MonoBehaviour
{



    public Text[] buttonList;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int moveCount;

    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    public int ScoreX = 0;
    public int ScoreO = 0;
    public Text ScoreTexeX;
    public Text ScoreTexeO;

    public AudioSource buttonClickAudio;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        playerSide = "x";
        moveCount=0;
        SetGameControllerReferenceOnButtons();
        restartButton.SetActive(false);
        SetPlayerColor(playerX, playerO);
    }

    void start()
    {
        
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (var i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);                  
        }
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text==playerSide && buttonList[1].text==playerSide && buttonList[2].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if(buttonList[2].text==playerSide && buttonList[8].text==playerSide && buttonList[6].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text==playerSide && buttonList[8].text==playerSide && buttonList[4].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text==playerSide && buttonList[5].text==playerSide && buttonList[7].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text==playerSide && buttonList[3].text==playerSide && buttonList[6].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text==playerSide && buttonList[8].text==playerSide && buttonList[5].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text==playerSide && buttonList[4].text==playerSide && buttonList[7].text==playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text==playerSide && buttonList[8].text==playerSide && buttonList[7].text==playerSide)
        {
            GameOver(playerSide);
        }

        else if (moveCount>=9)
        {
            GameOver("Draw");
        }
        else
        {
            ChangSide();
        }
    }

    void SetPlayerColor(Player newPlayer,Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string WinningPlayer)
    {
        SetBoardInteractable(false);
        if(WinningPlayer=="Draw")
        {
            SetGameOverText("It's a Draw!");
        }
        else
        {
            SetGameOverText(WinningPlayer+" Win!");
        }
        AddScoreX(WinningPlayer);
        AddScoreO(WinningPlayer);
        restartButton.SetActive(true);
    }

    void ChangSide()
    {
        playerSide=(playerSide=="x")?"o":"x";
        if(playerSide=="x")
        {
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            SetPlayerColor(playerO, playerX);
        }
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text=value;
    }

    public void Restartgame()
    {
        playerSide="x";
        moveCount=0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text="";
        }
        SetPlayerColor(playerX, playerO);
        restartButton.SetActive(false);
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void AddScoreX(string WinningScore)
    {
        if(WinningScore=="x")
        {
            ScoreX++;
            ScoreTexeX.text = ScoreX.ToString();
        }
    }

    void AddScoreO(string WinningScore)
    {
        if(WinningScore=="o")
        {
            ScoreO++;
            ScoreTexeO.text = ScoreO.ToString();
        }
    }

    public void PlayButtonClick()
    {
        buttonClickAudio.Play();
    }

    
}