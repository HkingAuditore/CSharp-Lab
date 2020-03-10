using System;


//武器
[Flags]
public enum Weapon : uint
{
    DoubleActionRevolver = 0x001,
    SchofieldRevolver = 0x002,
    M1899Pistol = 0x004,
    MauserPistol = 0x008,
    SpringfieldRifle = 0x010,
    LancasterRepeater = 0x020,
    CarcanoRifle = 0x040,
    DoubleBarreledShotgun = 0x080,
    SawedOffShotgun = 0x0100,

}

public class BasicWeapon
{
	public BasicWeapon()
	{
	}
}
