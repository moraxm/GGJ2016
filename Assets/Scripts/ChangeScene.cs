using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void changeScene(int sceneTo){
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneTo);	
	}

}