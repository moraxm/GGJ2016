using UnityEngine;
using System.Collections;

public class InventaryRune : MonoBehaviour 
{
	public RunesUI runesUi;
	int m_currentLevel;
	int m_runeCount;
	// Use this for initialization
	void Start () {
		m_currentLevel = 1;
		m_runeCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void CollectRune()
	{
		++m_runeCount;
		runesUi.nextRune = true;
		if (m_runeCount >= m_currentLevel) 
		{
			m_runeCount = 0;
			++m_currentLevel;
			runesUi.nextLevel = true;
		}
	}
		
	public void DropRune()
	{

	}

}
