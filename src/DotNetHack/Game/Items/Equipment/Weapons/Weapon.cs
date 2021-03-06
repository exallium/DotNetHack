﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// Weapon
    /// </summary>
    [Serializable]
    public abstract class Weapon : Item, IWeapon
    {
        public Weapon()
        { }

        /// <summary>
        /// creates a new weapon
        /// </summary>
        /// <param name="aName">the name of the weapon</param>
        /// <param name="aGlyph">the weapon glyph</param>
        /// <param name="aColor">the weapon colour</param>
        /// <param name="l">the weapon location.</param>
        /// <param name="aWProps">weapon properties</param>
        /// <param name="aLoc">worn location</param>
        /// <param name="aSubType">weapon subtype</param>
        public Weapon(string aName, char aGlyph, Colour aColor, Location3i l,
            WeaponProperties aWProps, WeaponLocation aLoc, WeaponSubType aSubType)
            : base(ItemType.Weapon, aName, aGlyph, aColor, l)
        {
            WeaponProperties = aWProps;
            WeaponSubType = aSubType;
            WeaponLocation = aLoc;
        }

        /// <summary>
        /// WeaponProperties
        /// </summary>
        public WeaponProperties WeaponProperties { get; set; }

        /// <summary>
        /// the worn weapon location
        /// </summary>
        public WeaponLocation WeaponLocation { get; set; }

        /// <summary>
        /// the type of weapon this is
        /// </summary>
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// the various weapon subtypes allow for further classification.
        /// </summary>
        public WeaponSubType WeaponSubType { get; set; }

        /// <summary>
        /// The overall health of this weapon.
        /// </summary>
        public int Condition
        {
            get { return WeaponProperties.Condition; }
            set
            {
                // the maximum condition can not be exceeded.
                if (value > WeaponProperties.MaxCondition)
                    WeaponProperties.Condition = WeaponProperties.MaxCondition;
                else WeaponProperties.Condition = value;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        /// <summary>
        /// Loads all available weapons and returns them as an array.
        /// </summary>
        /// <returns></returns>
        public static Weapon[] Load()
        {
            return null;
        }
    }
}