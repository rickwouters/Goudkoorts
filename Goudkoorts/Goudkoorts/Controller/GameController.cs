﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

public class GameController
{

    public BoardController boardController;
    public GameView gameView;
    private int startingInterval;
    private Timer timer;
    private Boolean gameOver;

    public GameController()
    {
        boardController = new BoardController();
        gameView = new GameView();

        startingInterval = 2000;
        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Interval = startingInterval;

        gameOver = false;
    }

	public virtual int Turns
	{
		get;
		set;
	}

	public virtual int Score
	{
		get;
		set;
	}

	public virtual GameView GameView
	{
		get;
		set;
	}

	public virtual GameModel GameModel
	{
		get;
		set;
	}

	public virtual BoardController BoardController
	{
		get;
		set;
	}

    public void play()
    {
        gameOver = false;

        gameView.showWelcome();
        boardController.generateBoard(12, 8);

        gameView.showBoard(boardController.getBoard(), boardController.score);

        timer.Start();

        while (!gameOver)
        {
            var input = gameView.getInput();
            if (input == 's')
            {
                endGame();
            }
            else
            {
                boardController.turnSwitch(input);
                gameView.showBoard(boardController.getBoard(), boardController.score);
            }
        }
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (!boardController.simulateTurn())
        {
            gameView.showCrash();
            endGame();
        }

        if (Turns % 5 == 0)
        {
            boardController.spawnMinecarts();
        }
        gameView.showBoard(boardController.getBoard(), boardController.score);
        Turns++;
        timer.Interval = (startingInterval - Turns * 10) + 500;
    }
    
	

    private void endGame()
    {
        timer.Stop();
        gameOver = true;
        if (gameView.GameOver())
        {
            restart();
        }
        else
        {
            gameView.showExit();
            System.Environment.Exit(1);
        }
    }
    
    private void restart()
	{
        timer.Interval = startingInterval;
		boardController = new BoardController();
        play();
	}

}

