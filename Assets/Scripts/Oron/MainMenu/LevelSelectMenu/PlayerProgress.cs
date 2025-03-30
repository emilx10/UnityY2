using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class PlayerProgress
{
  public List<LevelProgress> levels = new List <LevelProgress>();
}
