using TroboBot.Domain.Enum;

namespace TroboBot.Domain
{
    public  class StreamerFactory
    {
        public Streamer? Obter(StreamerEnum chave)
        {
            switch (chave)
            {
                case StreamerEnum.Ishi:
                    return new IshiStreamer();

                case StreamerEnum.Bia:
                    return new BiaStreamer();
                default:
                    return null;
            }
        }
    }
}
