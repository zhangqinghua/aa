using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScore : MonoBehaviour {

	void Start () {
		GetComponent<Text>().text = "最高得分：" + PlayerPrefs.GetInt("HighScore");
	}
	
}
