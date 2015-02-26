﻿using UnityEngine;
using System.Collections;

namespace Includes
{
    public class ProjectileStats
    {
        // NEUTRAL
        public class Fireball
        {
            public static float damage = 10;
        }

        // WATER
        public class Iceshard
        {
            public static float damage = 10;
        }
    }
    public class EnemyStats
    {
        // NEUTRAL
        public class Neutral
        {
            public static float maxHealth = 100;
            public static float damage = 10;
            public static float defence = 2;
            public static float waterResist = 5;
            public static float earthResist = 5;
            public static float fireResist = 5;
        }

        // WATER
        public class Water
        {
            public static float maxHealth = 100;
            public static float damage = 10;
            public static float defence = 2;
            public static float waterResist = 5;
            public static float earthResist = 5;
            public static float fireResist = 5;
        }

        // FIRE
        public class Fire
        {
            public static float maxHealth = 100;
            public static float damage = 10;
            public static float defence = 2;
            public static float waterResist = 5;
            public static float earthResist = 5;
            public static float fireResist = 5;
        }

        // EARTH
        public class Earth
        {
            public static float maxHealth = 100;
            public static float damage = 10;
            public static float defence = 2;
            public static float waterResist = 5;
            public static float earthResist = 5;
            public static float fireResist = 5;
        }
    }
    public enum Elements { NEUTRAL, FIRE, EARTH, FROST };
}
