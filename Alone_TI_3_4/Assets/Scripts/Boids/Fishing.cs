using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Fishing : MonoBehaviour
{
    public float fishingRange = 10.0f;
    public Transform flockManagerPeixes; // Assuma que este é o objeto que representa onde os peixes estão

    public List<FlockManager> flockManagers = new List<FlockManager>();
    public Text fishCountText;
    public Text notificationText;

    private int fishCount = 0;
    private bool isCasting = false;
    private float nextFishingTime = 0.0f;
    private float fishingCooldown = 5.0f; // Tempo de espera entre pescarias
    private int fishCountThreshold = 3; // Número de peixes necessário para acionar o tempo de espera
    private float waitTimeAfterThreshold = 10.0f; // Tempo de espera após atingir o limite de peixes pescados
    private bool waitingAfterThreshold = false;

    public FlockManager flockManager; // Adiciona uma referência ao FlockManager
    public float distanceThreshold = 5.0f; // Distância limite para o jogador iniciar a pescaria


    void Start()
    {
        flockManagers.AddRange(FindObjectsOfType<FlockManager>());
        UpdateFishCountText();
        SetNextFishingTime();
    }

    void Update()
    {
        // Verifica se o jogador está perto da área dos peixes e pressiona F para iniciar a pescaria
        if (!isCasting && Time.time >= nextFishingTime && Input.GetKeyDown(KeyCode.F) && IsPlayerNearMargin())
        {
            StartFishing();
        }

        if (waitingAfterThreshold)
        {
            // Aguardar após atingir o limite de peixes pescados
            if (Time.time >= nextFishingTime)
            {
                waitingAfterThreshold = false;
                SetNextFishingTime();
            }
        }
    }

    void StartFishing()
    {
        Debug.Log("Iniciando pescaria...");
        isCasting = true;
        ShowNotification("Lançando a isca... Aguarde um pouco.");

        // Simulação de espera antes de pescar (você pode ajustar o tempo conforme necessário)
        Invoke("CheckForFish", 3.0f);
    }

    void CheckForFish()
    {
        Debug.Log("Verificando se pescou algo...");

        if (Random.Range(0f, 1f) < 0.5f)
        {
            FishCaught(); // Simula 50% de chance de pescar algo
        }
        else
        {
            Debug.Log("Nenhum peixe foi pescado. Tente novamente!");
        }

        isCasting = false;
        SetNextFishingTime();
    }

    void FishCaught()
    {
        Debug.Log("Você pescou um peixe!");
        fishCount++;
        UpdateFishCountText();

        if (fishCount >= fishCountThreshold)
        {
            // Se atingir o limite de peixes pescados, esperar um tempo antes da próxima pescaria
            waitingAfterThreshold = true;
            nextFishingTime = Time.time + waitTimeAfterThreshold;
            ShowNotification("Você pescou " + fishCountThreshold + " peixes! Aguardando um pouco antes da próxima pescaria.");
        }
        else
        {
            ShowNotification("Você pescou um peixe!");
        }
    }

    void SetNextFishingTime()
    {
        nextFishingTime = Time.time + fishingCooldown;
        ShowNotification("Pronto para outra pescaria em breve.");
    }

    void UpdateFishCountText()
    {
        if (fishCountText != null)
        {
            fishCountText.text = "Peixes: " + fishCount;
        }
    }

    void ShowNotification(string message)
    {
        if (notificationText != null)
        {
            notificationText.text = message;
            Invoke("ClearNotification", 2.0f);
        }
    }

    void ClearNotification()
    {
        if (notificationText != null)
        {
            notificationText.text = string.Empty;
        }
    }

    bool IsPlayerNearFlockManagerPeixes()
    {
        // Verifica se o jogador está próximo ao objeto que representa onde os peixes estão
        return Vector3.Distance(transform.position, flockManagerPeixes.position) < 2.0f;
    }

    bool IsPlayerNearMargin()
    {
        // Verifica se o jogador está próximo à margem usando a função do FlockManager
        return flockManager.IsPlayerNearMargin(transform, distanceThreshold);
    }
}
