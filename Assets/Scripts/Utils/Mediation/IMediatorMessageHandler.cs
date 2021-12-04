namespace UnityGame.Mediation
{
    /// <summary>
    /// Defines a Handler for a Mediator Message of type TMessage
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IMediatorMessageHandler<in TMessage>
        where TMessage : IMediatorMessage
    {
        /// <summary>
        /// Handle a Message
        /// </summary>
        /// <param name="message">The message to handle</param>
        void Handle(TMessage message);
    }
}
