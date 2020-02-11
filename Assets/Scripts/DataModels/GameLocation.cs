using System;
using System.Collections.Generic;
using DefaultNamespace;

namespace DataModels
{
  [Serializable]
  public class GameLocation: ICloneable
  {
    public string Name { get; set; }
    public LocationType Type { get; set; }
    public Asset Image { get; set; }
    public string Description { get; set; }
    public bool Hidden { get; set; }
    
    // Relations
    public GamePlayerDataModel Player { get; set; }
    
    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
