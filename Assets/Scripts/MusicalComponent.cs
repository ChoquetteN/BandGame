using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalComponent
{
    private Dictionary<int, string> noteName { get; set; }

    public int noteNameLength { get { return noteName.Count; }  }
    public string instrumentName{  get; set; }

    public MusicalComponent()
    {
        noteName = new Dictionary<int, string>();
    }

    public void addNote(int boundKey,string note)
    {
        noteName.Add(boundKey,note);
    }

    public void playSound(int key)
    {
        SoundManager.Instance.AddCommand(instrumentName + noteName[key]);
    }
}
