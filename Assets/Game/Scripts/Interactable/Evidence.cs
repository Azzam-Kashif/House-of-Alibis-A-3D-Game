using UnityEngine;
using UnityEngine.UI;

public class Evidence : BaseInteractable
{
    public string evidenceName; // Name of the evidence for identification
    public int evidenceValue; // Value of the evidence (optional)

    private bool isCollected = false;
    private EvidenceManager evidenceManager;

    private void Start()
    {
        evidenceManager = FindObjectOfType<EvidenceManager>();

        // Check if this evidence has already been collected
        if (UserData.GetEvidence(evidenceName) > 0)
        {
            Destroy(gameObject);
            isCollected = true;
        }
    }

    public override void Interact()
    {
        if (!isCollected)
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Destroy the evidence
        Destroy(gameObject);
        // Mark the evidence as collected in PlayerPrefs
        UserData.SetEvidence(evidenceName, 1);

        // Update the evidence count in EvidenceManager
        evidenceManager.CollectEvidence(evidenceName, evidenceValue);

        isCollected = true;
    }
}
