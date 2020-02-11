using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.EventSystems;

namespace StateMachines
{
  public interface IState<TStateType, TModel> where TStateType: Enum
  {
    TStateType CurrentStateType { get; set; }
    TModel DataModel { get; }

    void Update();
    IEnumerable<TStateType> PossibleStateTransitions();
  }
}
