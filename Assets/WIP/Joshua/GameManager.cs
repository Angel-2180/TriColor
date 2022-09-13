using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject text;
    public GameObject PopUp_Parent;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        Debug.Log("Restart");
        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator StartGame()
    {
        Time.timeScale = 1f;
        GameObject newPopUP = Instantiate(text, PopUp_Parent.transform, false);
        newPopUP.transform.parent = PopUp_Parent.transform;
        newPopUP.SetActive(true);
        newPopUP.GetComponentInChildren<TextMeshProUGUI>().text = "3";
        yield return new WaitForSeconds(1f);

        Destroy(newPopUP);
        GameObject newPopUP1 = Instantiate(text, PopUp_Parent.transform, false);
        newPopUP1.transform.parent = PopUp_Parent.transform;
        newPopUP1.SetActive(true);
        newPopUP1.GetComponentInChildren<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(1f);

        Destroy(newPopUP1);
        GameObject newPopUP2 = Instantiate(text, PopUp_Parent.transform, false);
        newPopUP2.transform.parent = PopUp_Parent.transform;
        newPopUP2.SetActive(true);
        newPopUP2.GetComponentInChildren<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(1f);

        Destroy(newPopUP2);
        GameObject newPopUP3 = Instantiate(text, PopUp_Parent.transform, false);
        newPopUP3.transform.parent = PopUp_Parent.transform;
        newPopUP3.SetActive(true);
        newPopUP3.GetComponentInChildren<TextMeshProUGUI>().text = "GO !";

        yield return new WaitForSeconds(1f);
        Destroy(newPopUP3);
        //start Game
        FindObjectOfType<Music>().YourFunction();
    }
}