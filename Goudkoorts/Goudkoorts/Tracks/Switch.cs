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

public class Switch : Track
{

	public virtual Track PrimaryNext
	{
		get;
		set;
	}

	public virtual Track SecondaryNext
	{
		get;
		set;
	}

	public virtual Track PrimaryPrevious
	{
		get;
		set;
	}

	public virtual Track SecondaryPrevious
	{
		get;
		set;
	}

	public Switch(Track primaryNext, Track secondaryNext, Track primaryPrevious, Track secondaryPrevious)
	{

		if(secondaryPrevious != null && secondaryNext != null)
		{
			throw new Exception("can only have 1 secondary track set parameter 2 or 4 to null");
		}
		if(secondaryPrevious == null && secondaryNext == null)
		{
			throw new Exception("please insert 1 secodary");
		}

		PrimaryNext = primaryNext;
		SecondaryNext = secondaryNext;

		PrimaryPrevious = primaryPrevious;
		SecondaryNext = secondaryPrevious;

		NextTrack = PrimaryNext;
		PreviousTrack = PrimaryPrevious;
	}

    public void changeDirection()
    {

        if (!ContainsMinecart)
        {
            if (SecondaryNext != null)
            {
                if (PrimaryNext == NextTrack)
                {
                    NextTrack = SecondaryNext;
                }
                else
                {
                    NextTrack = PrimaryNext;
                }
            }

            if (SecondaryPrevious != null)
            {
                if (PrimaryPrevious == PreviousTrack)
                {
                    PreviousTrack = SecondaryPrevious;
                }
                else
                {
                    PreviousTrack = PrimaryPrevious;
                }
            }
        }

    }

	public override char getChar()
	{

		if (ContainsMinecart)
		{
			return '0';
		}

		if(SecondaryPrevious == PreviousTrack || PrimaryNext == NextTrack)
		{
			return '/';
		}
		return '\\';
	}


}

