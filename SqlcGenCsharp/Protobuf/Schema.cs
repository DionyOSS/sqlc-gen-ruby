using System.Collections.Generic;
using ProtoBuf;

namespace sqlc_gen_csharp.Protobuf;

[ProtoContract]
public class Schema
{
    [ProtoMember(1)]
    public string Comment { get; set; } = "";

    [ProtoMember(2)]
    public string Name { get; set; } = "";

    [ProtoMember(3)]
    public List<Table> Tables { get; set; } = new List<Table>();

    [ProtoMember(4)]
    public List<Enum> Enums { get; set; } = new List<Enum>();

    [ProtoMember(5)]
    public List<CompositeType> CompositeTypes { get; set; } = new List<CompositeType>();

    // Additional constructor, methods, or logic as needed
}