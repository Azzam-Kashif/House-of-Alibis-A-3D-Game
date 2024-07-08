using UnityEngine;
using UnityEngine.UI;

public class EvidenceManager : MonoBehaviour
{
    public Text evidenceCountText;

    private int evidenceCount = 0;

    private void Start()
    {
        // Load the evidence count from PlayerPrefs
        evidenceCount = PlayerPrefs.GetInt("EvidenceCount", 0);

        // Update the evidence count text
        UpdateEvidenceCountText();
    }

    public void CollectEvidence(string evidenceName, int value)
    {
        // Increment the evidence count by the specified value
        evidenceCount += value;

        // Update the evidence count text
        UpdateEvidenceCountText();

        // Save the evidence count permanently
        PlayerPrefs.SetInt("EvidenceCount", evidenceCount);
        PlayerPrefs.Save();

        // Mark the evidence as collected in PlayerPrefs
        UserData.SetEvidence(evidenceName, 1);
    }

    private void UpdateEvidenceCountText()
    {
        // Update the evidence count text to display the current count
        evidenceCountText.text = evidenceCount.ToString();
    }
}
