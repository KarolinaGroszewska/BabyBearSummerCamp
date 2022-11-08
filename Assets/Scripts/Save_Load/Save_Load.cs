
using System.Timers;
using System.Threading.Tasks.Sources;
using System.IO.Enumeration;
using System.Security.AccessControl;
//using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Data.SqlTypes;
//using System.Reflection.PortableExecutable;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Save_Load : MonoBehaviour
{
    
    public int slot;
    public GameObject Currency;
  
    void Start()
    {
        
    }

    public int getCurrency(){
        String currencyString = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>().text;
        String value = currencyString.Substring(1);

        return Int16.Parse(value);
    }


    public async void save(){

        SaveObj save1 = new SaveObj {
            currency = getCurrency(),
        };
        
        String json = JsonUtility.ToJson(save1);
        

        
        


        if(slot == 1){ 
            if(File.Exists(Application.dataPath + "/Scripts/Save_Load/save1.txt")){
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save1.txt", json);

                GameObject.Find("Save1Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save1Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
            }else{
                File.Create(Application.dataPath + "/Scripts/Save_Load/save1.txt");
                GameObject.Find("Save1Button").GetComponentInChildren<TextMeshProUGUI>().text = "Saving!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save1.txt", json);

                GameObject.Find("Save1Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save1Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
  
            }
            
        }else if(slot == 2){
            if(File.Exists(Application.dataPath + "/Scripts/Save_Load/save2.txt")){
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save2.txt", json);

                GameObject.Find("Save2Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save2Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
            }else{
                File.Create(Application.dataPath + "/Scripts/Save_Load/save2.txt");
                GameObject.Find("Save2Button").GetComponentInChildren<TextMeshProUGUI>().text = "Saving!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save2.txt", json);
                GameObject.Find("Save2Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save2Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
            }
        }else{
            if(File.Exists(Application.dataPath + "/Scripts/Save_Load/save3.txt")){
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save3.txt", json);
                
                GameObject.Find("Save3Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save3Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
            }else{
                File.Create(Application.dataPath + "/Scripts/Save_Load/save3.txt");
                GameObject.Find("Save3Button").GetComponentInChildren<TextMeshProUGUI>().text = "Saving!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                File.WriteAllText(Application.dataPath + "/Scripts/Save_Load/save3.txt", json);

                GameObject.Find("Save3Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Saved!";
                await Task.Delay(TimeSpan.FromSeconds(1f));
                GameObject.Find("Save3Button").GetComponentInChildren<TextMeshProUGUI>().text  = "Slot 1";
            }
        }
    }
    
    public async void load(){
        if(slot == 1){
            await Task.Delay(TimeSpan.FromSeconds(3f));
            string saveString = File.ReadAllText(Application.dataPath + "/Scripts/Save_Load/save1.txt");
            SaveObj saveObject = JsonUtility.FromJson<SaveObj>(saveString);
            await Task.Delay(TimeSpan.FromSeconds(3f));
            Currency.GetComponent<TextMeshProUGUI>().text = "$" + saveObject.currency;
        }
    }
    
    private class SaveObj
    {
        public int currency;

        
    }
    
}

