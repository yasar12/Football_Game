using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;
    [SerializeField] private Rigidbody[] allRigidbodies;
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;
    public int goalCount = 0;
    public TextMeshProUGUI text;
    static public int levelCount = 1;
    private int attemptCount = 0;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private void Start()
    {
        heart1 = GameObject.Find("Heart1")?.GetComponent<Image>();
        heart2 = GameObject.Find("Heart2")?.GetComponent<Image>();
        heart3 = GameObject.Find("Heart3")?.GetComponent<Image>();
    }
    private void Update()
    {

        text.text = "" + goalCount;
            
        switch (attemptCount)
        {
            case 0:
                break;
            case 1:
                heart3.enabled = false;
                break;
            case 2:
                heart2.enabled = false;
                break;
        }

    }
    public static void nextLevel(int goalCount)
    {
        if (goalCount == 3)
        {
            levelCount++;
            PlayerPrefs.SetInt("LevelCount", levelCount);
            SceneManager.LoadScene("LevelSuccessMenu");
            goalCount = 0;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            goalCount++;
            ResetRigidbodiesToInitialPositions();
        }

        if (other.gameObject.CompareTag("Unplayable"))
        {
            ResetRigidbodiesToInitialPositions();
            if (attemptCount == 2)
            {
                SceneChanger sc = new SceneChanger();
                sc.RestartScene();
            }
        
            attemptCount++;
        
        }
    }

    private void Awake()
    {
        instance = this;

        // Tüm Rigidbody bileşenlerini al
        allRigidbodies = FindObjectsOfType<Rigidbody>();

        // Başlangıç pozisyonları ve rotasyonları saklamak için diziler oluştur
        initialPositions = new Vector3[allRigidbodies.Length];
        initialRotations = new Quaternion[allRigidbodies.Length];

        // Başlangıç pozisyonlarını ve rotasyonları kaydet
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            initialPositions[i] = allRigidbodies[i].position;
            initialRotations[i] = allRigidbodies[i].rotation;
        }
    }
    
    public void ResetRigidbodiesToInitialPositions()
    {
        // Tüm Rigidbody bileşenlerini başlangıç pozisyonlarına ve rotasyonlarına geri döndürür
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].position = initialPositions[i];
            allRigidbodies[i].rotation = initialRotations[i];
            allRigidbodies[i].velocity = Vector3.zero;
            allRigidbodies[i].angularVelocity = Vector3.zero;
        }
    }
}
