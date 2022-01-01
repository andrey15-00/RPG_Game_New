namespace UnityGame.Mediation
{
    public interface IMediator<T> where T: IMediatorMessage
    {
        /// <summary>
        /// Sends a message to multiple handlers.
        /// </summary>
        void Publish<MsgType>(MsgType message) where MsgType : T;

        /// <summary>
        /// Subscriber a handler to given event.
        /// </summary>
        void SubscribeHandler<HandlerType, MsgType>(HandlerType subscriber)
            where MsgType : IMediatorMessage
            where HandlerType : IMediatorMessageHandler<MsgType>;
    }
}
