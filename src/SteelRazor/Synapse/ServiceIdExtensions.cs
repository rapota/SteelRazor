namespace SteelRazor.Synapse;

internal static class ServiceIdExtensions
{
    public static Guid DecodeId(this Guid id)
    {
        // Original id: e6bef332-95b8-76ec-a6d0-9f402bad244c
        byte[] bytes = id.ToByteArray();
        Guid key = Guid.Parse("9b62e44a-71d7-4aa8-b352-1a644e15b9c8");

        return bytes[0] == 0x61 && bytes[15] == 0x2E
            ? Process(id, key)
            : id;
    }

    private static Guid Process(Guid guid, Guid key)
    {
        byte[] id = guid.ToByteArray();
        byte[] bytes = key.ToByteArray();

        for (int i = 0; i < id.Length; i++)
        {
            id[i] = (byte)(id[i] ^ bytes[i]);
        }

        return new Guid(id);
    }
}