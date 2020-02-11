using System;
using UnityEditor.VersionControl;

namespace DataModels
{
  [Serializable]
  public class GamePlayerDataModel
  {
    public string Name { get; set; }
    public Asset Image { get; set; }
  }
}
