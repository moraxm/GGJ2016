using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {


	/**
	 * Public Atributtes
	 */
	public float life;
	public Scrollbar scrollbar;

	/**
	 * Private Atributtes 
	 */
	private float maxLife;

	// Use this for initialization
	void Start () {
		maxLife = life;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * If return true the character is alive
	 * else the character is dead.
	 */
	public bool decreaseLife (float amountToDecrease){
		life -= amountToDecrease;
		scrollbar.size = life / maxLife;

		return life > 0;
	}
}
