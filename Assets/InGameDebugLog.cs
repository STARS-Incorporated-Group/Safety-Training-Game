 using UnityEngine;
 using TMPro; // For TextMeshPro
 using System.Collections.Generic; // For List

 public class InGameDebugLog : MonoBehaviour
 {
     public TMP_Text debugTextUI; // Assign your TextMeshPro UGUI element here
     public int maxLines = 15; // Max number of lines to display

     private Queue<string> logMessages = new Queue<string>();

     // Singleton pattern to allow easy access from other scripts
     public static InGameDebugLog Instance { get; private set; }

     void Awake()
     {
         if (Instance == null)
         {
             Instance = this;
             // DontDestroyOnLoad(gameObject); // Optional: if you want it to persist across scenes
         }
         else
         {
             Destroy(gameObject);
             return;
         }

         if (debugTextUI == null)
         {
             Debug.LogError("DebugTextUI is not assigned in InGameDebugLog!");
             enabled = false; // Disable if not set up
         }
     }

     public void Log(string message)
     {
         if (!enabled || debugTextUI == null) return;

         string formattedMessage = $"[{System.DateTime.Now:HH:mm:ss}] {message}";

         if (logMessages.Count >= maxLines)
         {
             logMessages.Dequeue(); // Remove the oldest message
         }
         logMessages.Enqueue(formattedMessage);

         UpdateDebugText();
     }

     void UpdateDebugText()
     {
         string fullLog = "";
         foreach (string msg in logMessages)
         {
             fullLog += msg + "\n";
         }
         debugTextUI.text = fullLog;
     }

     // Optional: Hook into Unity's own debug log system
     void OnEnable()
     {
         Application.logMessageReceived += HandleUnityLog;
     }

     void OnDisable()
     {
         Application.logMessageReceived -= HandleUnityLog;
     }

     void HandleUnityLog(string logString, string stackTrace, LogType type)
     {
         // You can filter by type if you want (e.g., only show errors)
         // if (type == LogType.Error || type == LogType.Exception)
         // {
         //    Log($"UNITY {type}: {logString}");
         // }
         // For now, let's log everything that Unity logs:
         Log($"SYS-{type}: {logString}");
     }
 }