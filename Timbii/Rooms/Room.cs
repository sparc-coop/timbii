using Newtonsoft.Json;
using Sparc.Blossom.Authentication;
using Sparc.Blossom.Realtime.Matrix;

namespace Timbii;

public enum RoomTypes
{
    Chat
}

public enum RoomMembership
{
    None,
    Knocked,
    Invited,
    Joined,
    Banned
}

public enum JoinTypes
{
    Public,
    Invite,
    Knock,
    Restricted,
    KnockRestricted
}

// Modeled from https://github.com/matrix-org/matrix-js-sdk/blob/develop/src/models/room.ts
public class Room : BlossomEntity<string>
{
    [JsonConstructor]
    private Room()
    {
        Creator = new();
    }

    public Room(string roomId, BlossomAvatar creator)
    {
        Id = roomId;
        Creator = creator;
    }

    public Dictionary<string, int> NotificationCounts { get; set; } = [];
    public List<BlossomAvatar> Members { get; set; } = [];
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string DisplayName => Name ?? Summary?.Name ?? CalculateNameFromMembers();
    public string? Alias { get; set; }
    public string? Topic { get; set; }
    public JoinTypes JoinRule { get; set;  }

    public RoomTypes Type { get; set; } = RoomTypes.Chat;

    public BlossomAvatar Creator { get; set; }
    public BlossomAvatar? Avatar { get; set; }
    public Dictionary<string, Dictionary<string, object>> Tags { get; set; } = [];
    public Dictionary<string, MatrixEvent> AccountData { get; set; } = [];
    public MatrixRoomSummary? Summary { get; set; }
    public long LastActive { get; set; }
    public RoomMembership MyMembership { get; set; } = RoomMembership.None;

    string CalculateNameFromMembers()
    {
        if (Members.Count == 0)
            return "Empty Room";
        if (Members.Count == 1)
            return Members[0].Name;
        if (Members.Count == 2)
            return $"{Members[0].Name} & {Members[1].Name}";

        return $"{Members[0].Name} +{Members.Count - 1}";
    }


    // public RoomReceipts RoomReceipts;



}