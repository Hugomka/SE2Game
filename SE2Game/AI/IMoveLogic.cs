using SE2Game.Utils;

namespace SE2Game.AI
{
    public interface IMoveLogic
    {
        string Name { get; }

        /// <summary>Determine the next move for an entity.</summary>
        /// <example><code>
        /// direction = moveLogic.MakeMove(this.position, World.Instance.Player.Position);
        /// </code></example>
        /// <param name="currentPosition">Current position of the entity. Most
        /// likely, you will pass this.position for this parameter.</param>
        /// <param name="targetPosition">Goal to be reached. Most likely, you
        /// will pass World.Instance.Player.Position for this parameter.</param>
        /// <returns>The direction to go. Most likely, this will be placed in
        /// the this.direction variable.</returns>
        Vector MakeMove(Vector currentPosition, Vector targetPosition);
    }
}
