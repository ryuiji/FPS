using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Gun))]
public class GunScriptEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        Gun myGunScript = (Gun)target;
        myGunScript.fireType = (FireType)EditorGUILayout.EnumPopup("Fire Type", myGunScript.fireType);
        switch (myGunScript.fireType)
        {
            case FireType.Automatic:
                myGunScript.roundsPerMinute = EditorGUILayout.FloatField("Rounds per Minute", myGunScript.roundsPerMinute);
                break;
            case FireType.SemiAutomatic:
                myGunScript.semiFireRate = EditorGUILayout.FloatField("Time between shots", myGunScript.semiFireRate);
                break;
            case FireType.BoltOrPumpAction:
                myGunScript.pumpTime = EditorGUILayout.FloatField("Pump Time", myGunScript.pumpTime);
                break;

        }
        myGunScript.ammoInClip = EditorGUILayout.IntField("Current Amount of Bullets", myGunScript.ammoInClip);
        myGunScript.fullAmmoInClip = EditorGUILayout.IntField("Max Amount of Bullets", myGunScript.fullAmmoInClip);
        myGunScript.reloadSpeed = EditorGUILayout.FloatField("Time spent Reloading", myGunScript.reloadSpeed);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("EmptySound");
        myGunScript.emptySound =  (AudioClip)  EditorGUILayout.ObjectField(myGunScript.emptySound, typeof(AudioClip) , true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("ShotSound");
        myGunScript.shot = (AudioClip)EditorGUILayout.ObjectField(myGunScript.shot, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("CockSound");
        myGunScript.pumpSound = (AudioClip)EditorGUILayout.ObjectField(myGunScript.pumpSound, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("ReloadSound");
        myGunScript.reloadSound = (AudioClip)EditorGUILayout.ObjectField(myGunScript.reloadSound, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();

    }
}
