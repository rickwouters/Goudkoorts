﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Goudkoorts.Model;
using Goudkoorts.Tracks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public class BoardController
{


    private Dictionary<String, Block> board;
    private int _width;
    private int _height;
    private Water firstBlockWater;

	public virtual IEnumerable<Minecart> Minecart
	{
		get;
		set;
	}

	public virtual IEnumerable<Ship> Ship
	{
		get;
		set;
	}

	public virtual BoardModel BoardModel
    {
        get;
        set;
    }

	private Track lastTrack
	{
		get;
		set;
	}

    public int score
    {
        get;
        set;
    }

	private List<Minecart> carts;
    private List<Ship> ships;
	private List<Switch> switches;
	private List<Silo> silos;

    public BoardController()
    {
        score = 0;
    }

	public virtual string getBoard()
	{
        String expBoard = "";

		Water currentBlock = firstBlockWater;

		while(currentBlock.NextBlock != null)
		{

			expBoard += currentBlock.getChar();

			currentBlock = currentBlock.NextBlock;

		}
		expBoard += Environment.NewLine;
		for (int y = 0; y < _height; y++)
			
        {

			for (int x = 0; x < _width; x++)
			{

                expBoard += board[x + "-" + y].getChar();

            }
            expBoard += Environment.NewLine;
        }
        return expBoard;
    }

    //weet niet zeker of dit public of private moet worden
    public void generateBoard(int Width, int Height)
    {
        board = new Dictionary<string, Block>();

        _height = Height;
        _width = Width;

        firstBlockWater = new Water();
        Water currentBlock = firstBlockWater;

        for(int i = 0; i < _width; i++)
        {

            currentBlock = currentBlock.NextBlock = new Water();

        }


        for (int x = 0; x < _width; x++)
        {

            for (int y = 0; y < _height; y++)
            {
                board.Add(x + "-" + y, new EmptyBlock());

            }

        }

		switches = new List<Switch>();
		carts = new List<global::Minecart>();
        ships = new List<global::Ship>();
		silos = new List<Silo>();
		buildBoard();
    }

	public void buildBoard()
	{
		//looks fucked but builds the track

		Track nexttrack;
		Track currentTrack = new Rail();
		Track PreviousTrack;

		for(int i = 0; i < 12; i++)
		{

			Embarkment rail = new Embarkment();

			board[i + "-0"] = rail;
			Debug.WriteLine(i + "-0");

			if(i != 0)
			{
				rail.NextTrack = (Track)board[(i - 1) + "-0"];
			}

		}

		for(int i = 10; i > -1; i--)
		{

			Track rail = (Track)board[i + "-0"];

			rail.PreviousTrack = (Track)board[(i + 1) + "-0"];

		}
		currentTrack = (Track)board["11-0"];

		PreviousTrack = new Rail();
		PreviousTrack.NextTrack = currentTrack;

		currentTrack.PreviousTrack = PreviousTrack;

		currentTrack = PreviousTrack;		

		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["11-1"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["11-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["11-3"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["10-3"] = currentTrack;

		Rail primaryPrev = new Rail();
		Rail SecondaryPrev = new Rail();

		Switch newSwitch = new Switch(currentTrack, null, primaryPrev, SecondaryPrev);

		switches.Add(newSwitch);

		currentTrack.PreviousTrack = newSwitch;

		primaryPrev.NextTrack = newSwitch;
		SecondaryPrev.NextTrack = newSwitch;

		board["9-3"] = newSwitch;

		currentTrack = SecondaryPrev;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["9-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["8-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["7-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["6-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["5-2"] = currentTrack;

		Track primaryNext = currentTrack;
		Track secondaryNext = new Rail();

		PreviousTrack = new Rail();

		newSwitch = new Switch(primaryNext, secondaryNext, PreviousTrack, null);

		switches.Add(newSwitch);

		primaryNext.PreviousTrack = newSwitch;
		secondaryNext.PreviousTrack = newSwitch;

		PreviousTrack.NextTrack = newSwitch;

		board["5-3"] = newSwitch;

		currentTrack = PreviousTrack;

		board["4-3"] = currentTrack;

		primaryPrev = new Rail();
		SecondaryPrev = new Rail();

		newSwitch = new Switch(currentTrack, null, primaryPrev, SecondaryPrev);

		switches.Add(newSwitch);

		currentTrack.PreviousTrack = newSwitch;

		primaryPrev.NextTrack = newSwitch;
		SecondaryPrev.NextTrack = newSwitch;

		board["3-3"] = newSwitch;

		currentTrack = SecondaryPrev;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["3-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["2-2"] = currentTrack;

		currentTrack = PreviousTrack;
		PreviousTrack = new Rail();

		currentTrack.PreviousTrack = PreviousTrack;
		PreviousTrack.NextTrack = currentTrack;

		board["1-2"] = currentTrack;

		Silo silo = new Silo { NextTrack = currentTrack };

		silos.Add(silo);

		board["0-2"] = silo;

	}

    public void buildBoard1()
    {

        // dit moet handmatig, hieronder staat een voorbeeld voor hoe het moet

        board["0-0"] = new Rail();
        board["1-1"] = new Rail();
		board["0-2"] = new Rail();

		switches.Add(new Switch((Track)board["1-1"], null, (Track)board["0-0"], (Track)board["0-2"]));

		board["0-1"] = switches[0];



        carts.Add(new Minecart((Track)board["0-2"]));
        ships.Add(new Ship(firstBlockWater));
        firstBlockWater.hasShip = true;
    }

    public Boolean simulateTurn()
    {

        foreach (Minecart e in carts)
        {
            if (!e.Move())
            {
                return false;
            }
        }

        foreach (Ship e in ships)
        {
            e.Move();
        }

        return true;
    }

	public void turnSwitch(char switchChar)
	{
        int switchNumber = 0;

        int.TryParse(switchChar.ToString(), out switchNumber);
        int index = switchNumber - 1;
        if (index >= 0 && index < switches.Count)
        {
            switches[index].changeDirection();
        }		
	}

}

