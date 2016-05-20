using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ClickEvents : MonoBehaviour {
	public void LoadScene(){
		SceneManager.LoadScene ("Game");
	}

	public void Exit(){
		Application.Quit ();
	}
}
