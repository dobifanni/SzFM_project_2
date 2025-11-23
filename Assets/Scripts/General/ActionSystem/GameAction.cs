using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction
{
    public List<GameAction> PreReaction { get; private set; } = new();
    public List<GameAction> PerformReaction { get; private set; } = new();
    public List<GameAction> PostReaction { get; private set; } = new();

    public string Name { get; private set; }

    public GameAction() { }
    public GameAction(string name) { Name = name; }
}
