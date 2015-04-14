﻿using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]
public class Board : MonoBehaviour 
{
	public List<Gem> gems = new List<Gem>();
	public GameUI score;
	public int GridWidth;
	public int GridHeight;
	public GameObject gemPrefab;
	public Gem lastGem;
	public Vector3 gem1Start,gem1End,gem2Start,gem2End;
	public bool isSwapping = false;
	public bool SwapBack =false;
	public Gem gem1,gem2;
	public float startTime;
	public float SwapRate =2;
	public int AmountToMatch = 3;
	public bool isMatched = false;
	public AudioClip matched;
	// Use this for initialization
	void Start () 
	{
		for(int y=0;y<GridHeight;y++)
		{
			for(int x=0;x<GridWidth;x++)
			{
				GameObject g = Instantiate(gemPrefab,new Vector3(x,y,0),Quaternion.identity)as GameObject;
				g.transform.parent = gameObject.transform;
				gems.Add(g.GetComponent<Gem>());
			}
		}
		gameObject.transform.position = new Vector3(-2.5f,-2f,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isMatched)
		{
			for(int i=0;i<gems.Count;i++)
			{
				if(gems[i].isMatched)
				{
					gems[i].CreateGem();
					gems[i].transform.position = new Vector3(
						gems[i].transform.position.x,
						gems[i].transform.position.y + GridHeight,
						gems[i].transform.position.z);
					if(GameUI.score <=4900){
						GameUI.score += 100;
					}
					else{
						GameUI.score = 5000;
					}
				}
			}
			isMatched = false;
		}
		else if(isSwapping)
		{
			MoveGem(gem1,gem1End,gem1Start);
			MoveNegGem(gem2,gem2End,gem2Start);
			if(Vector3.Distance(gem1.transform.position,gem1End) <.1f ||Vector3.Distance(gem2.transform.position,gem2End) <.1f)
			{
				gem1.transform.position = gem1End;
				gem2.transform.position = gem2End;
				
				lastGem = null;
				isSwapping =false;
				TogglePhysics(false);
				if(!SwapBack)
				{
					gem1.ToggleSelector();
					gem2.ToggleSelector();
					CheckMatch();
				}
				else
				{
					SwapBack = false;
				}
			}
		}
		else if(!DetermineBoardState())
		{
			for(int i =0 ;i<gems.Count;i++)
			{
				CheckForNearbyMatches(gems[i]);
			}
			if(!DoesBoardContainMatches())
			{
				isMatched = true;
				for(int i=0;i<gems.Count;i++)
				{
					gems[i].isMatched = true;

				}
				GameUI.score -= GridWidth*GridHeight*100;
			}
		}
		
	}
	public bool DetermineBoardState()
	{
		for(int i=0;i<gems.Count;i++)
		{
			if(gems[i].transform.localPosition.y > GridHeight)
			{
				print("Both");
				return true;
			}
			if(gems[i].GetComponent<Rigidbody>().velocity.y > 0.1f)
			{
				return true;
			}
			
		}
		return false;
	}
	
	public void CheckMatch()
	{
		List<Gem> gem1List = new List<Gem>();
		List<Gem> gem2List = new List<Gem>();
		ConstructMatchList(gem1.color,gem1,gem1.XCoord,gem1.YCoord,ref gem1List);
		FixMatchList(gem1,gem1List);
		ConstructMatchList(gem2.color,gem2,gem2.XCoord,gem2.YCoord,ref gem2List);
		FixMatchList(gem2,gem2List);
		if(!isMatched)
		{
			SwapBack = true;
			ResetGems();
		}
		
	}
	
	public void ResetGems()
	{
		gem1Start = gem1.transform.position;
		gem1End = gem2.transform.position;
		
		gem2Start = gem2.transform.position;
		gem2End = gem1.transform.position;
		
		startTime = Time.time;
		TogglePhysics(true);
		isSwapping = true;
	}
	
	
	public void CheckForNearbyMatches(Gem g)
	{
		List<Gem> gemList = new List<Gem>();
		ConstructMatchList(g.color,g,g.XCoord,g.YCoord,ref gemList);
		FixMatchList(g,gemList);
	}
	
	public void ConstructMatchList(string color,Gem gem,int XCoord,int YCoord, ref List<Gem> MatchList)
	{
		if(gem == null)
		{
			return;
		}
		else if(gem.color != color)
		{
			return;
		}
		else if(MatchList.Contains(gem))
		{
			return;
		}
		else
		{
			MatchList.Add(gem);
			if(XCoord == gem.XCoord || YCoord == gem.YCoord)
			{
				foreach(Gem g in gem.Neighbors)
				{
					ConstructMatchList(color,g,XCoord,YCoord,ref MatchList);
				}
			}
		}
		
	}
	public bool DoesBoardContainMatches()
	{
		//TogglePhysics(true);
		for(int i=0;i<gems.Count;i++)
		{
			for(int j =0;j<gems.Count;j++)
			{
				if(gems[i].IsNeighborWith(gems[j]))
				{
					Gem g  = gems[i];
					Gem f = gems[j];
					Vector3 GTemp = g.transform.position;
					Vector3 FTemp = f.transform.position;
					List<Gem> tempNeighbors = new List<Gem>(g.Neighbors);
					g.transform.position = FTemp;
					f.transform.position =GTemp;
					g.Neighbors = f.Neighbors;
					f.Neighbors = tempNeighbors;
					List<Gem> testListG = new List<Gem>();
					ConstructMatchList(g.color,g,g.XCoord,g.YCoord,ref testListG);
					if(TestMatchList(g,testListG))
					{
						g.transform.position = GTemp;
						f.transform.position = FTemp;
						f.Neighbors = g.Neighbors;
						g.Neighbors = tempNeighbors;
						TogglePhysics(false);
						return true;
					}
					List<Gem> testListF = new List<Gem>();
					ConstructMatchList(f.color,f,f.XCoord,f.YCoord,ref testListF);
					if(TestMatchList(f,testListF))
					{
						g.transform.position = GTemp;
						f.transform.position = FTemp;
						f.Neighbors = g.Neighbors;
						g.Neighbors = tempNeighbors;
						TogglePhysics(false);
						return true;
					}
					
					g.transform.position = GTemp;
					f.transform.position = FTemp;
					f.Neighbors = g.Neighbors;
					g.Neighbors = tempNeighbors;
					TogglePhysics(false);
				}
			}
		}
		return false;
	}
	
	public bool TestMatchList(Gem gem, List<Gem> ListToFix)
	{
		List<Gem> rows = new List<Gem>();
		List<Gem> collumns = new List<Gem>();
		for(int i=0;i<ListToFix.Count;i++)
		{
			if(gem.XCoord == ListToFix[i].XCoord)
			{
				rows.Add(ListToFix[i]);
			}
			if(gem.YCoord == ListToFix[i].YCoord)
			{
				collumns.Add(ListToFix[i]);
			}
		}
		if(rows.Count >= AmountToMatch)
		{
			return true;
		}
		if(collumns.Count >= AmountToMatch)
		{
			return true;
		}
		
		return false;
	}
	public void FixMatchList(Gem gem, List<Gem> ListToFix)
	{
		List<Gem> rows = new List<Gem>();
		List<Gem> collumns = new List<Gem>();
		for(int i=0;i<ListToFix.Count;i++)
		{
			if(gem.XCoord == ListToFix[i].XCoord)
			{
				rows.Add(ListToFix[i]);
			}
			if(gem.YCoord == ListToFix[i].YCoord)
			{
				collumns.Add(ListToFix[i]);
			}
		}
		if(rows.Count >= AmountToMatch)
		{
			isMatched = true;
			for(int i=0;i<rows.Count;i++)
			{
				rows[i].isMatched = true;

			}
			GetComponent<AudioSource>().PlayOneShot(matched);


		}
		if(collumns.Count >= AmountToMatch)
		{
			isMatched = true;
			for(int i=0;i<collumns.Count;i++)
			{
				collumns[i].isMatched = true;

			}
			GetComponent<AudioSource>().PlayOneShot(matched);
		}
	}
	
	public void MoveGem(Gem gemToMove,Vector3 toPos,Vector3 fromPos)
	{
		Vector3 center = (fromPos + toPos) *.5f;
		center -= new Vector3(0,0,.1f);
		Vector3 riseRelCenter = fromPos - center;
		Vector3 setRelCenter = toPos - center;
		float fracComplete = (Time.time - startTime + 0.3f);//SwapRate;
		gemToMove.transform.position = Vector3.Slerp(riseRelCenter,setRelCenter,fracComplete);
		gemToMove.transform.position += center;
	}
	public void MoveNegGem(Gem gemToMove,Vector3 toPos,Vector3 fromPos)
	{
		Vector3 center = (fromPos + toPos) *.5f;
		center -= new Vector3(0,0,-.1f);
		Vector3 riseRelCenter = fromPos - center;
		Vector3 setRelCenter = toPos - center;
		float fracComplete = (Time.time - startTime + 0.3f);//SwapRate;
		gemToMove.transform.position = Vector3.Slerp(riseRelCenter,setRelCenter,fracComplete);
		gemToMove.transform.position += center;
	}
	public void TogglePhysics(bool isOn)
	{
		for(int i=0;i<gems.Count;i++)
		{
			gems[i].GetComponent<Rigidbody>().isKinematic = isOn;
		}
	}
	public void SwapGems(Gem currentGem)
	{
		if(lastGem == null)
		{
			lastGem = currentGem;
		}
		else if(lastGem == currentGem)
		{
			lastGem = null;
		}
		else
		{
			if(lastGem.IsNeighborWith(currentGem))
			{
				gem1Start = lastGem.transform.position;
				gem1End = currentGem.transform.position;
				
				gem2Start = currentGem.transform.position;
				gem2End = lastGem.transform.position;
				
				startTime = Time.time;
				TogglePhysics(true);
				gem1 = lastGem;
				gem2 = currentGem;
				isSwapping = true;
			}
			else
			{
				lastGem.ToggleSelector();
				lastGem = currentGem;
			}
		}
	}
}
