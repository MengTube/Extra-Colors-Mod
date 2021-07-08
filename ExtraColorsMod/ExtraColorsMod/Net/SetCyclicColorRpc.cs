using Hazel;
using Reactor;
using Reactor.Networking;

namespace ExtraColorsMod.Net
{
    [RegisterCustomRpc((uint)CustomRpcCalls.SetCyclicColor)]
    public class SetCyclicColorRpc : PlayerCustomRpc<ExtraColorsModPlugin, SetCyclicColorRpc.Data>
    {
        public SetCyclicColorRpc(ExtraColorsModPlugin plugin, uint id) : base(plugin, id) { }

        public readonly struct Data
        {
            public readonly byte Placeholder;

            public Data(byte placeholder)
            {
                Placeholder = placeholder;
            }
        }

        public override RpcLocalHandling LocalHandling => RpcLocalHandling.None;

        public override void Write(MessageWriter writer, Data data)
        {
            writer.Write(data.Placeholder);
        }

        public override Data Read(MessageReader reader)
        {
            return new Data(reader.ReadByte());
        }

        public override void Handle(PlayerControl innerNetObject, Data data)
        {

        }
    }
}