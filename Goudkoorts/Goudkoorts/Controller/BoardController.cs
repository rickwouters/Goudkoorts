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
using System.Linq;
using System.Text;

public class BoardController
{


    private Dictionary<String, Block> board;
    private int _width;
    private int _height;
    private Water firstBlockWater;

    public virtual Track SpawnLocations
	{
		get;
		set;
	}

	public virtual IEnumerable<Track> Track
	{
		get;
		set;
	}

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

	private List<Minecart> carts;
	private List<Switch> switches;

	public virtual string ShowBoard()
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
		buildBoard1();
    }

	public void buildBoard()
	{

		board["0-0"] = new Rail();
		board["0-1"] = new Rail();
		board["0-2"] = new Rail();
		board["0-3"] = new Rail();

		board["0-0"].NextBlock = board["0-1"];
		board["0-1"].NextBlock = board["0-2"];
		board["0-2"].NextBlock = board["0-3"];

		carts.Add(new Minecart((Track)board["0-1"]));


	}

    public void buildBoard1()
    {

        // dit moet handmatig, hieronder staat een vvorbeeld voor hoe het moet

        board["0-0"] = new Rail();
        board["1-1"] = new Rail();
		board["0-2"] = new Rail();

		switches.Add(new Switch((Track)board["1-1"], null, (Track)board["0-0"], (Track)board["0-2"]));

		board["0-1"] = switches[0];



		carts.Add(new Minecart((Track)board["0-2"]));
    }

	public Boolean simulateTurn()
	{

		foreach(Minecart e in carts){

			if (!e.Move())
			{
				return false;
			}

		}

		return true;

	}

	public void turnSwitch(int index)
	{
		switches[index].changeDirection();
	}

}

