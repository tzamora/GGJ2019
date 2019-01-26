
// Generic InControl PlayerActionSet.

// 2015/10/19 04:41 PM


using InControl;


public class GameInputActions : PlayerActionSet
{
    // Joystick
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Movement;

    // Basic actions
    public PlayerAction attack;

    public GameInputActions()
    {
        // Joystick
        Left = CreatePlayerAction("MoveLeft");
        Right = CreatePlayerAction("MoveRight");
        Up = CreatePlayerAction("MoveUp");
        Down = CreatePlayerAction("MoveDown");

        Movement = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

        // Actions
        attack = CreatePlayerAction("attack");
    }
}
