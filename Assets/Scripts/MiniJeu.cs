using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textNouveauRecord;
    public TMP_InputField inputNom;

    public GameObject panneauNom;

    void Start()
    {
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }

    public void Terminer()
    {
        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);
        if (pointageTemps > recordActuel)
        {
            Debug.Log("Nouveau record :)");
            panneauNom.SetActive(true);
            textNouveauRecord.text = textScore.text;
        }
    }

    public void ConfirmerNouveauRecord()
    {
        string nom = inputNom.text;
        PlayerPrefs.SetString("nomJoueur", nom);
        panneauNom.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
