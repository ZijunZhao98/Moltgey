using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Dialogue : ScriptableObject {
     private Saying[] words;
     public Saying[] Words
     {
         get
         {
             return words;
         }
     }
 }
 
 public class Saying
 {
     private string talkerName;
     public string TalkerName
     {
         get
         {
             return talkerName;
         }
     }
 
     private string words;
     public string Words
     {
         get
         {
             return words;
         }
     }
 }