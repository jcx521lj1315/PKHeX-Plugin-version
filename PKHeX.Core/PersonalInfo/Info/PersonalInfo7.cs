using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace PKHeX.Core;

/// <summary>
/// <see cref="PersonalInfo"/> class with values from the Sun &amp; Moon games.
/// </summary>
public sealed class PersonalInfo7(Memory<byte> Raw)
    : PersonalInfo, IPersonalAbility12H, IPersonalInfoTM, IPersonalInfoTutorType
{
    public const int SIZE = 0x54;

    private Span<byte> Data => Raw.Span;
    public override byte[] Write() => Raw.ToArray();

    public override int HP { get => Data[0x00]; set => Data[0x00] = (byte)value; }
    public override int ATK { get => Data[0x01]; set => Data[0x01] = (byte)value; }
    public override int DEF { get => Data[0x02]; set => Data[0x02] = (byte)value; }
    public override int SPE { get => Data[0x03]; set => Data[0x03] = (byte)value; }
    public override int SPA { get => Data[0x04]; set => Data[0x04] = (byte)value; }
    public override int SPD { get => Data[0x05]; set => Data[0x05] = (byte)value; }
    public override byte Type1 { get => Data[0x06]; set => Data[0x06] = value; }
    public override byte Type2 { get => Data[0x07]; set => Data[0x07] = value; }
    public override byte CatchRate { get => Data[0x08]; set => Data[0x08] = value; }
    public override int EvoStage { get => Data[0x09]; set => Data[0x09] = (byte)value; }
    private int EVYield { get => ReadUInt16LittleEndian(Data[0x0A..]); set => WriteUInt16LittleEndian(Data[0x0A..], (ushort)value); }
    public override int EV_HP { get => (EVYield >> 0) & 0x3; set => EVYield = (EVYield & ~(0x3 << 0)) | ((value & 0x3) << 0); }
    public override int EV_ATK { get => (EVYield >> 2) & 0x3; set => EVYield = (EVYield & ~(0x3 << 2)) | ((value & 0x3) << 2); }
    public override int EV_DEF { get => (EVYield >> 4) & 0x3; set => EVYield = (EVYield & ~(0x3 << 4)) | ((value & 0x3) << 4); }
    public override int EV_SPE { get => (EVYield >> 6) & 0x3; set => EVYield = (EVYield & ~(0x3 << 6)) | ((value & 0x3) << 6); }
    public override int EV_SPA { get => (EVYield >> 8) & 0x3; set => EVYield = (EVYield & ~(0x3 << 8)) | ((value & 0x3) << 8); }
    public override int EV_SPD { get => (EVYield >> 10) & 0x3; set => EVYield = (EVYield & ~(0x3 << 10)) | ((value & 0x3) << 10); }
    public bool Telekenesis { get => ((EVYield >> 12) & 1) == 1; set => EVYield = (EVYield & ~(0x1 << 12)) | ((value ? 1 : 0) << 12); }
    public int Item1 { get => ReadInt16LittleEndian(Data[0x0C..]); set => WriteInt16LittleEndian(Data[0x0C..], (short)value); }
    public int Item2 { get => ReadInt16LittleEndian(Data[0x0E..]); set => WriteInt16LittleEndian(Data[0x0E..], (short)value); }
    public int Item3 { get => ReadInt16LittleEndian(Data[0x10..]); set => WriteInt16LittleEndian(Data[0x10..], (short)value); }
    public override byte Gender { get => Data[0x12]; set => Data[0x12] = value; }
    public override byte HatchCycles { get => Data[0x13]; set => Data[0x13] = value; }
    public override byte BaseFriendship { get => Data[0x14]; set => Data[0x14] = value; }
    public override byte EXPGrowth { get => Data[0x15]; set => Data[0x15] = value; }
    public override int EggGroup1 { get => Data[0x16]; set => Data[0x16] = (byte)value; }
    public override int EggGroup2 { get => Data[0x17]; set => Data[0x17] = (byte)value; }
    public int Ability1 { get => Data[0x18]; set => Data[0x18] = (byte)value; }
    public int Ability2 { get => Data[0x19]; set => Data[0x19] = (byte)value; }
    public int AbilityH { get => Data[0x1A]; set => Data[0x1A] = (byte)value; }

    public override int EscapeRate { get => Data[0x1B]; set => Data[0x1B] = (byte)value; }
    public override int FormStatsIndex { get => ReadUInt16LittleEndian(Data[0x1C..]); set => WriteUInt16LittleEndian(Data[0x1C..], (ushort)value); }
    public int FormSprite { get => ReadUInt16LittleEndian(Data[0x1E..]); set => WriteUInt16LittleEndian(Data[0x1E..], (ushort)value); }
    public override byte FormCount { get => Data[0x20]; set => Data[0x20] = value; }
    public override int Color { get => Data[0x21] & 0x3F; set => Data[0x21] = (byte)((Data[0x21] & 0xC0) | (value & 0x3F)); }
    public bool SpriteFlip { get => ((Data[0x21] >> 6) & 1) == 1; set => Data[0x21] = (byte)((Data[0x21] & ~0x40) | (value ? 0x40 : 0)); }
    public bool SpriteForm { get => ((Data[0x21] >> 7) & 1) == 1; set => Data[0x21] = (byte)((Data[0x21] & ~0x80) | (value ? 0x80 : 0)); }

    public override int BaseEXP { get => ReadUInt16LittleEndian(Data[0x22..]); set => WriteUInt16LittleEndian(Data[0x22..], (ushort)value); }
    public override int Height { get => ReadUInt16LittleEndian(Data[0x24..]); set => WriteUInt16LittleEndian(Data[0x24..], (ushort)value); }
    public override int Weight { get => ReadUInt16LittleEndian(Data[0x26..]); set => WriteUInt16LittleEndian(Data[0x26..], (ushort)value); }

    public int SpecialZ_Item { get => ReadUInt16LittleEndian(Data[0x4C..]); set => WriteUInt16LittleEndian(Data[0x4C..], (ushort)value); }
    public int SpecialZ_BaseMove { get => ReadUInt16LittleEndian(Data[0x4E..]); set => WriteUInt16LittleEndian(Data[0x4E..], (ushort)value); }
    public int SpecialZ_ZMove { get => ReadUInt16LittleEndian(Data[0x50..]); set => WriteUInt16LittleEndian(Data[0x50..], (ushort)value); }
    public bool LocalVariant { get => Data[0x52] == 1; set => Data[0x52] = value ? (byte)1 : (byte)0; }

    public override int AbilityCount => 3;
    public override int GetIndexOfAbility(int abilityID) => abilityID == Ability1 ? 0 : abilityID == Ability2 ? 1 : abilityID == AbilityH ? 2 : -1;
    public override int GetAbilityAtIndex(int abilityIndex) => abilityIndex switch
    {
        0 => Ability1,
        1 => Ability2,
        2 => AbilityH,
        _ => throw new ArgumentOutOfRangeException(nameof(abilityIndex), abilityIndex, null),
    };

    private const int TMHM = 0x28;
    private const int CountTM = 100;
    private const int CountHM = 5;
    private const int CountTMHM = CountTM + CountHM;
    private const int ByteCountTM = (CountTMHM + 7) / 8;
    private const int TypeTutor = 0x38;
    private const int TypeTutorCount = 8;

    public bool GetIsLearnTM(int index)
    {
        if ((uint)index >= CountTMHM)
            return false;
        return (Data[TMHM + (index >> 3)] & (1 << (index & 7))) != 0;
    }

    public void SetIsLearnTM(int index, bool value)
    {
        if ((uint)index >= CountTMHM)
            return;
        if (value)
            Data[TMHM + (index >> 3)] |= (byte)(1 << (index & 7));
        else
            Data[TMHM + (index >> 3)] &= (byte)~(1 << (index & 7));
    }

    public void SetAllLearnTM(Span<bool> result, ReadOnlySpan<ushort> moves)
    {
        var span = Data.Slice(TMHM, ByteCountTM);
        for (int index = CountTMHM - 1; index >= 0; index--)
        {
            if ((span[index >> 3] & (1 << (index & 7))) != 0)
                result[moves[index]] = true;
        }
    }

    public bool GetIsLearnTutorType(int index)
    {
        if ((uint)index >= 8)
            return false;
        return (Data[TypeTutor + (index >> 3)] & (1 << (index & 7))) != 0;
    }

    public void SetIsLearnTutorType(int index, bool value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual<uint>((uint)index, TypeTutorCount);
        if (value)
            Data[TypeTutor + (index >> 3)] |= (byte)(1 << (index & 7));
        else
            Data[TypeTutor + (index >> 3)] &= (byte)~(1 << (index & 7));
    }

    public void SetAllLearnTutorType(Span<bool> result, ReadOnlySpan<ushort> moves)
    {
        var tutor = Data[TypeTutor];
        for (int index = TypeTutorCount - 1; index >= 0; index--)
        {
            if ((tutor & (1 << (index & 7))) != 0)
                result[moves[index]] = true;
        }
    }

    private const int Tutor1 = 0x3C;
    private const int TutorCount1 = 67;
    private const int ByteCountTutor1 = (TutorCount1 + 7) / 8;

    public bool GetIsLearnTutorSpecial(int index)
    {
        if ((uint)index >= TutorCount1)
            return false;
        return (Data[Tutor1 + (index >> 3)] & (1 << (index & 7))) != 0;
    }

    public bool GetIsLearnTutorSpecial(ushort move)
    {
        var index = BattlePointTutorMoves.IndexOf(move);
        if (index < 0)
            return false;
        return (Data[Tutor1 + (index >> 3)] & (1 << (index & 7))) != 0;
    }

    public void SetAllLearnTutorSpecial(Span<bool> result)
    {
        var moves = BattlePointTutorMoves;
        var span = Data.Slice(Tutor1, ByteCountTutor1);
        for (int index = 0; index < moves.Length; index++)
        {
            if ((span[index >> 3] & (1 << (index & 7))) != 0)
                result[moves[index]] = true;
        }
    }

    /// <summary>
    /// Battle Point Tutor moves corresponding to their index within Tutor bitflag permissions.
    /// </summary>
    public static ReadOnlySpan<ushort> BattlePointTutorMoves =>
    [
        450, 343, 162, 530, 324, 442, 402, 529, 340, 067, 441, 253, 009, 007, 008,
        277, 335, 414, 492, 356, 393, 334, 387, 276, 527, 196, 401,      428, 406, 304, 231,
        020, 173, 282, 235, 257, 272, 215, 366, 143, 220, 202, 409,      264, 351, 352,
        380, 388, 180, 495, 270, 271, 478, 472, 283, 200, 278, 289, 446,      285,

        477, 502, 432, 710, 707, 675, 673,
    ];

    /// <summary>
    /// Technical Machine moves corresponding to their index within TM bitflag permissions.
    /// </summary>
    public static ReadOnlySpan<ushort> MachineMoves =>
    [
        526, 337, 473, 347, 046, 092, 258, 339, 474, 237,
        241, 269, 058, 059, 063, 113, 182, 240, 355, 219,
        218, 076, 479, 085, 087, 089, 216, 141, 094, 247,
        280, 104, 115, 482, 053, 188, 201, 126, 317, 332,
        259, 263, 488, 156, 213, 168, 490, 496, 497, 315,
        211, 411, 412, 206, 503, 374, 451, 507, 693, 511,
        261, 512, 373, 153, 421, 371, 684, 416, 397, 694,
        444, 521, 086, 360, 014, 019, 244, 523, 524, 157,
        404, 525, 611, 398, 138, 447, 207, 214, 369, 164,
        430, 433, 528, 057, 555, 267, 399, 127, 605, 590,

        // No HMs
    ];
}
