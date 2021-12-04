namespace UnityGame.Mediation
{
    public interface IMediator
    {
        /// <summary>
        /// Sends a message to multiple handlers with a void return type
        /// </summary>
        void Publish<MsgType>(MsgType message) where MsgType : IMediatorMessage;

        void SubscribeHandler<HandlerType, MsgType>(HandlerType subscriber)
            where MsgType : IMediatorMessage
            where HandlerType : IMediatorMessageHandler<MsgType>;
    }
}
